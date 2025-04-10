using System;
using System.Collections.Generic;

namespace PortfolioProject.Core.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DetailedDescription { get; set; }
        public string FeaturedImage { get; set; }
        public string SeoUrl { get; set; }
        public string ClientName { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Technologies { get; set; } // Comma separated technologies
        public string Category { get; set; }
        public string LiveUrl { get; set; }
        public string GitHubUrl { get; set; }
        public bool IsFeatured { get; set; } = false;
        public int UserId { get; set; }
        
        // Navigation properties
        public User User { get; set; }
        public ICollection<ProjectImage> ProjectImages { get; set; }
    }
}
