using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace EVE.Data
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable
            where T : class
    {
        private IDbSet<T> _entities;

        private string _errorMessage = string.Empty;

        private bool _isDisposed;

        //public GenericRepository(IUnitOfWork<DbContext> unitOfWork) : this(unitOfWork.Context)
        //{
        //}

        public GenericRepository(DbContext context)
        {
            _isDisposed = false;
            Context = context;
        }

        public DbContext Context { get; set; }

        public virtual IDbSet<T> Entities => _entities ?? (_entities = Context.Set<T>());

        #region IDisposable Members

        public void Dispose()
        {
            if(Context != null)
                Context.Dispose();
            _isDisposed = true;
        }

        #endregion

        #region IGenericRepository<T> Members

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                                          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                          string includeProperties = "")
        {IQueryable<T> query = Entities;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query)
                        .ToList();
            }

            var list = query.ToList();
            return query.ToList();
        }

        public virtual IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> filter = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                    string includeProperties = "")
        {
            IQueryable<T> query = Entities;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public virtual IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                             string includeProperties = "")
        {
            IQueryable<T> query = Entities;

            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query)
                        .ToList();
            }

            var list = query.ToList();

            return list;
        }

        public virtual IQueryable<T> GetAllAsQueryable(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                             string includeProperties = "")
        {
            IQueryable<T> query = Entities;

            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public virtual T GetById(object id)
        {
            return Entities.Find(id);
        }

        public virtual T Insert(T entity)
        {
            try
            {
                if(entity == null)
                    throw new ArgumentNullException(nameof(entity));

                if(Context == null || _isDisposed)
                    Context = new EVEEntities();
                return Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual T Update(T entity)
        {
            try
            {
                if(entity == null)
                    throw new ArgumentNullException(nameof(entity));
                if(Context == null || _isDisposed)
                    Context = new EVEEntities();

                return SetEntryModified(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual T Delete(T entity)
        {
            try
            {
                if(entity == null)
                    throw new ArgumentNullException(nameof(entity));
                if(Context == null || _isDisposed)
                    Context = new EVEEntities();

                return Entities.Remove(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                foreach (var validationError in validationErrors.ValidationErrors)
                    _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual T FindOne(Expression<Func<T, bool>> filter = null,
                                 string includeProperties = "")
        {
            IQueryable<T> query = Entities;

            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(filter != null)
            {
                return query.FirstOrDefault(filter);
            }

            return query.FirstOrDefault();
        }

        public string FixLength(Expression<Func<T, object>> predicate,
                                string value,
                                bool PadRight = true)
        {
            string tableName = typeof(T).Name;
            var memberExpression = (MemberExpression) predicate.Body;
            var propertyName = memberExpression.Member.Name;
            var oc = ((IObjectContextAdapter) Context).ObjectContext;
            var length = oc.MetadataWorkspace.GetItems(DataSpace.CSpace)
                           .OfType<EntityType>()
                           .Where(et => et.Name == tableName)
                           .SelectMany(et => et.Properties.Where(p => p.Name == propertyName))
                           .Select(p => p.MaxLength)
                           .FirstOrDefault();

            if(PadRight)
            {
                return value.Trim()
                            .PadRight(length.Value);
            }

            return value.Trim()
                        .PadLeft(length.Value);
        }

        #endregion

        public virtual IEnumerable<T> GetEx(object obj = null,
                                            Expression<Func<T, bool>> filter = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            string includeProperties = "")
        {
            IQueryable<T> query = Entities;

            if(filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if(orderBy != null)
            {
                return orderBy(query)
                        .ToList();
            }

            var list = query.ToList();
            return query.ToList();
        }

        public virtual T SetEntryModified(T entity)
        {
            Context.Entry(entity)
                   .State = EntityState.Modified;
            return entity;
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            try
            {
                if(entities == null)
                {
                    throw new ArgumentNullException("entities");
                }

                Context.Configuration.AutoDetectChangesEnabled = false;
                Context.Set<T>()
                       .AddRange(entities);
                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                throw new Exception(_errorMessage, dbEx);
            }
        }
    }
}
