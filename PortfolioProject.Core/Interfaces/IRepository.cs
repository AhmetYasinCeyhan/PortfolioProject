using PortfolioProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortfolioProject.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        // Query Methods
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);
        Task<T> GetByIdAsync(int id);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string includeProperties);

        // Insert Methods
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        // Update Methods
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);

        // Delete Methods
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteRangeAsync(IEnumerable<T> entities);

        // Other Methods
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
