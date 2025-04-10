using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Core.Interfaces;
using PortfolioProject.Web.ViewModels;
using System.Diagnostics;

namespace PortfolioProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var featuredProjects = await _unitOfWork.Projects.GetAsync(p => p.IsFeatured);
            var skills = await _unitOfWork.Skills.GetAsync(s => s.IsVisible);
            
            var viewModel = new HomeViewModel
            {
                FeaturedProjects = featuredProjects,
                Skills = skills
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
