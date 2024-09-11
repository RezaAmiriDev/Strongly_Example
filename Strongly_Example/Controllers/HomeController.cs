using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;
using Strongly_Example.Models;
using System.Diagnostics;

namespace Strongly_Example.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly MyCmsContext _context;
        private readonly IPageRepository _pageRepository;

        public HomeController(ILogger<HomeController> logger, MyCmsContext context, IPageRepository pageRepository)
        {
            _logger = logger;
            _context = context;
            _pageRepository = pageRepository;
        }


        public IActionResult Index()
        {
            return View();
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

        public ActionResult Slider()
        {
            return PartialView(_pageRepository.PageInSlider());
        }
    }
}
