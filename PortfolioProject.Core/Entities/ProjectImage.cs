using System;

namespace PortfolioProject.Core.Entities
{
    public class ProjectImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string AltText { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public int ProjectId { get; set; }
        
        // Navigation property
        public Project Project { get; set; }
    }
}
