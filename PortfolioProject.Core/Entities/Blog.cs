using System;
using System.Collections.Generic;

namespace PortfolioProject.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string FeaturedImage { get; set; }
        public string SeoUrl { get; set; }
        public bool IsPublished { get; set; } = false;
        public DateTime? PublishDate { get; set; }
        public int ViewCount { get; set; } = 0;
        public int UserId { get; set; }
        public string Tags { get; set; } // Comma separated tags

        // Navigation properties
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
