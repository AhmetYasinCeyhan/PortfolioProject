using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Core.Entities;

namespace PortfolioProject.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Entity DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Soft delete için global query filter
            modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.IsDeleted);
            modelBuilder.Entity<Project>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Contact>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Skill>().HasQueryFilter(s => !s.IsDeleted);
            modelBuilder.Entity<ProjectImage>().HasQueryFilter(pi => !pi.IsDeleted);

            // Blog - User ilişkisi (Many-to-One)
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.User)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Project - User ilişkisi (Many-to-One)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProjectImage - Project ilişkisi (Many-to-One)
            modelBuilder.Entity<ProjectImage>()
                .HasOne(pi => pi.Project)
                .WithMany(p => p.ProjectImages)
                .HasForeignKey(pi => pi.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment - Blog ilişkisi (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Blog)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            // Comment self-referencing ilişkisi (recursive relation)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany()
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
