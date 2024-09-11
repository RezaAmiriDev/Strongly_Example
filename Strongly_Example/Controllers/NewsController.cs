using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Strongly_Example.Controllers
{
    public class NewsController : Controller
    {
        private readonly MyCmsContext db;
        private readonly IGroupPageRepository _groupPageRepository;
        private readonly IPageRepository _pageRepository;
        private readonly IPageCommentRepository _pageCommentRepository;
        public NewsController(IGroupPageRepository groupPageRepository,MyCmsContext cmsContext, IPageRepository pageRepository,IPageCommentRepository pageCommentRepository)
        {
            _groupPageRepository = groupPageRepository;
            this.db = cmsContext;
            _pageRepository = pageRepository;
            _pageCommentRepository = pageCommentRepository;
        }   

        public IActionResult ShowGroups()
        {
            return PartialView(_groupPageRepository.GetGroupsForView());
        }

        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(_groupPageRepository.GetAllGroups());
        }

        public ActionResult TopNews()
        {
            return PartialView(_pageRepository.TopNews());
        }

        public ActionResult LastNews()
        {
            return PartialView(_pageRepository.LastNews());
        }
        [Route("Archive")]
        public ActionResult Archive()
        {
            return View(_pageRepository.GetAllPage());
        }
        public ActionResult ShowNewsByGroupId(int id,string title)
        {
            ViewBag.name = title;
            return View(_pageRepository.ShowPageByGroupId(id));
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = _pageRepository.GetPageById(id);
            if (news == null)
            {
                return NotFound();
            }
            news.visite += 1;
            _pageRepository.UpdatePage(news);
            _pageRepository.save();
            return View();
        }
        public ActionResult AddComment(int id ,string name , string email, string comment)
        {
            PageComment addComment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageId = id,
                Email = email,
                Name = name,
                Comment = comment
            };
            _pageCommentRepository.AddComment(addComment);
            return PartialView("ShowComment",_pageCommentRepository.GetCommentByNewsId(id));
        }
        public ActionResult ShowComment(int id)
        {
            return PartialView(_pageCommentRepository.GetCommentByNewsId(id));
        }

    }
}
