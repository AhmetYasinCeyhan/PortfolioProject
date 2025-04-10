using Microsoft.EntityFrameworkCore.Storage;
using PortfolioProject.Core.Entities;
using PortfolioProject.Core.Interfaces;
using PortfolioProject.Data.Context;
using System;
using System.Threading.Tasks;

namespace PortfolioProject.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private bool _disposed = false;

        // Repository'lerin lazy loading ile oluşturulması
        private IRepository<User> _users;
        private IRepository<Blog> _blogs;
        private IRepository<Project> _projects;
        private IRepository<ProjectImage> _projectImages;
        private IRepository<Comment> _comments;
        private IRepository<Contact> _contacts;
        private IRepository<Skill> _skills;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<User> Users => _users ??= new Repository<User>(_context);
        public IRepository<Blog> Blogs => _blogs ??= new Repository<Blog>(_context);
        public IRepository<Project> Projects => _projects ??= new Repository<Project>(_context);
        public IRepository<ProjectImage> ProjectImages => _projectImages ??= new Repository<ProjectImage>(_context);
        public IRepository<Comment> Comments => _comments ??= new Repository<Comment>(_context);
        public IRepository<Contact> Contacts => _contacts ??= new Repository<Contact>(_context);
        public IRepository<Skill> Skills => _skills ??= new Repository<Skill>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await _transaction.RollbackAsync();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
