using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace EVE.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable
            where TContext : DbContext, new()
    {
        //public GenericRepository<T> GenericRepository<T>()
        //        where T : class
        //{
        //    if(_repositories == null)
        //        _repositories = new Dictionary<string, object>();
        //    var type = typeof(T).Name;
        //    if(!_repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(GenericRepository<T>);
        //        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), Context);
        //        _repositories.Add(type, repositoryInstance);
        //    }

        //    return (GenericRepository<T>) _repositories[type];
        //}

        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        private bool _disposed;

        private string _errorMessage = string.Empty;

        private DbContextTransaction _objTran;

        //private Dictionary<string, object> _repositories;

        public UnitOfWork()
        {
            Context = new TContext();
        }

        public Dictionary<Type, object> Repositories
        {
            get => _repositories;
            set => Repositories = value;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IUnitOfWork<TContext> Members

        public TContext Context { get; }

        public void CreateTransaction()
        {
            _objTran = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _objTran.Commit();
        }

        public void Rollback()
        {
            _objTran?.Rollback();
            _objTran?.Dispose();
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage)
                                     + Environment.NewLine;
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public IGenericRepository<T> Repository<T>()
                where T : class
        {
            if(Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(Context);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
                if(disposing)
                    Context.Dispose();

            _disposed = true;
        }
    }
}
