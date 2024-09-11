using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Strongly_Example.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupPageController : Controller
    {

        private readonly IGroupPageRepository _groupPageRepository;
        private readonly MyCmsContext db;
        // Constructor injection
        public GroupPageController(IGroupPageRepository groupPageRepository, MyCmsContext db)
        {
           
            _groupPageRepository = groupPageRepository;
            this.db = db;
        }
        public ActionResult Index()
        {
            try
            {
                var list = _groupPageRepository.GetAllGroups();
                return View(list);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        // GET: GroupPageController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            GroupPage groupPage = _groupPageRepository.GetGroupById(id.Value);
            if (groupPage == null)
            {
                return NotFound();
            }
            return View(groupPage);
        }

        // GET: GroupPageController/Create
        public ActionResult Create()
        {
            return PartialView();
        }
        // POST: GroupPageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("GroupId,GroupTitle")] GroupPage groupPage)
        {
            if (ModelState.IsValid)
            {
                _groupPageRepository.InsertGroup(groupPage);
                _groupPageRepository.save();
                return RedirectToAction("Index");
            }
            return View(groupPage);
        }

        // GET: GroupPageController/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            GroupPage groupPage = _groupPageRepository.GetGroupById(id.Value);
            if (groupPage == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: GroupPageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("GroupId,GroupTitle")] GroupPage groupPage)
        {
            if (ModelState.IsValid)
            {
                _groupPageRepository.UpdateGroup(groupPage);
                _groupPageRepository.save();


                return RedirectToAction("Index");
            }
            return View(groupPage);
        }

        // GET: GroupPageController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();

            }
            GroupPage groupPage = _groupPageRepository.GetGroupById(id.Value);
            if (groupPage == null)
            { return NotFound(); }
            return View();
        }

        // POST: GroupPageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _groupPageRepository.DeleteGroup(id);
            _groupPageRepository.save();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _groupPageRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
