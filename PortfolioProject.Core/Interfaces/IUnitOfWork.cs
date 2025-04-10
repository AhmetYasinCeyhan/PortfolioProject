using System;
using System.Threading.Tasks;
using PortfolioProject.Core.Entities;

namespace PortfolioProject.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Entity tiplerine özel repository'leri tanımlama
        IRepository<User> Users { get; }
        IRepository<Blog> Blogs { get; }
        IRepository<Project> Projects { get; }
        IRepository<ProjectImage> ProjectImages { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Contact> Contacts { get; }
        IRepository<Skill> Skills { get; }

        // Transaction işlemleri
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
