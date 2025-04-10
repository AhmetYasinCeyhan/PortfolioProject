using System;

namespace PortfolioProject.Core.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Proficiency { get; set; } // 1-100 arası
        public string Category { get; set; } // Frontend, Backend, DevOps, vb.
        public string Icon { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public bool IsVisible { get; set; } = true;
    }
}
