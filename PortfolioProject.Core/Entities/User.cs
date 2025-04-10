using System;
using System.Collections.Generic;

namespace PortfolioProject.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Role { get; set; } // Admin, Editor, etc.
        public string Biography { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastLogin { get; set; }

        // Navigation properties
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
