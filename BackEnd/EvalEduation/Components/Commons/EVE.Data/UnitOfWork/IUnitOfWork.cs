using System.Data.Entity;

namespace EVE.Data
{
    public interface IUnitOfWork<out TContext>
            where TContext : DbContext, new()
    {
        TContext Context { get; }

        void CreateTransaction();

        void Commit();

        void Rollback();

        void Save();

        IGenericRepository<T> Repository<T>()
                where T : class;
    }
}
