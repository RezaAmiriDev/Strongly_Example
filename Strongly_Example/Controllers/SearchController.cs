using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Strongly_Example.Controllers
{
    public class SearchController : Controller
    {
        private readonly IPageRepository _pageRepository;
        MyCmsContext _context;
        public SearchController(IPageRepository pageRepository, MyCmsContext context)
        {
            _pageRepository = pageRepository;
            _context = context;
        }
        // GET: SearchController
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(_pageRepository.SearchPage(q));
        }
       
    }
}
