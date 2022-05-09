using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(Expression<Func<T, bool>> selector);
        IQueryable<T> GetAll();
        void Create(T item);
        void Delete(T entity);
        Task CreateAsync(T item);
        Task AddRange(IEnumerable<T> newEntities);
        void Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        Task UpdateRange(IEnumerable<T> entities);
        Task<int> SaveChangesAsync();
        int SaveChanges();

    }
}
