using PortfolioProject.Core.Entities;

namespace PortfolioProject.Web.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Project> FeaturedProjects { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public User ProfileInfo { get; set; }
    }
}
