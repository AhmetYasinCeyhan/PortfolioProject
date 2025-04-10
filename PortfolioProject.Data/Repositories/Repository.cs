using Microsoft.EntityFrameworkCore;
using PortfolioProject.Core.Entities;
using PortfolioProject.Core.Interfaces;
using PortfolioProject.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortfolioProject.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            IQueryable<T> query = _dbSet;
            
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await orderBy(query).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            IQueryable<T> query = _dbSet;
            
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // Include properties
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await orderBy(query).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, string includeProperties)
        {
            IQueryable<T> query = _dbSet;
            
            // Include properties
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public Task UpdateAsync(T entity)
        {
            // Entity state'i modified olarak işaretleme
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            // Soft Delete
            entity.IsDeleted = true;
            entity.UpdatedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                // Soft Delete
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                // Soft Delete
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.Now;
                _context.Entry(entity).State = EntityState.Modified;
            }
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(predicate);
        }
    }
}
