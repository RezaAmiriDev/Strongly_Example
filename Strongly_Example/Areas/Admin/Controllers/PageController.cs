
using ClassLibrary;
using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace Strongly_Example.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PageController : Controller
    {
        // Constructor injection
        private IPageRepository _pageRepository;
        private IGroupPageRepository groupPageRepository;
        private MyCmsContext _db;

        private readonly IWebHostEnvironment _webHostEnvironment;
        // GET: PageController
        public PageController(IWebHostEnvironment webHostEnvironment, IPageRepository pageRepository, IGroupPageRepository groupPageRepository, MyCmsContext db)
        {
            _webHostEnvironment = webHostEnvironment;
            this._pageRepository = pageRepository;
            this.groupPageRepository = groupPageRepository;
            this._db = db;
        }


        public ActionResult Index()
        {
            try
            {
               var list = this._pageRepository.GetAllPage();
                return View(list);
            }
            catch (Exception ex) { 
              return View(ex);
            }
        }
        // GET: PageController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Page page = _db.Pages.Find(id);
            if(page == null)
            {
                return NotFound();
            }
            return View(page);
        }

        // GET: PageController/Create
        public ActionResult Create()
        {
           ViewBag.GroupId = new SelectList(groupPageRepository.GetAllGroups(),"GroupId","GroupTitle");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("PageId,Title,ShortDiscreption,Text,visite,ImageName,GroupId,Tags")] Page page,IFormFile ImgUp)
        {
          if (ModelState.IsValid)
            {
                page.visite = 0;
                page.CreateDate = DateTime.Now;
                if (ImgUp != null && ImgUp.Length > 0)
                {
                    try
                    {
                        // Generate a unique filename
                        string imageName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUp.FileName);
                    // Get the path to the wwwroot folder
                    string src = Path.Combine(_webHostEnvironment.WebRootPath, "PageImages");
                    // Ensure the directory exists
                    if (!Directory.Exists(src))
                    {
                        Directory.CreateDirectory(src);
                    }
                    // Combine the folder path with the filename
                    string filePath = Path.Combine(src, imageName);
                 
                        // Save the file to the specified path
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                             ImgUp.CopyToAsync(fileStream);  // Await the async operation
                        }
                        // Set the ImageName property
                        page.ImageName = imageName;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception and handle it
                        // e.g., log the error, return an error message, etc.
                        ModelState.AddModelError("", "An error occurred while uploading the file.");
                        return View(page);  // Return to the view with the error message
                    }
                }
                _pageRepository.InsertPage(page);
                _pageRepository.save();
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(_db.Groups, "GroupID", "GroupTitle", page.GroupId);
            return View(page);
        }

        // GET: PageController/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Page page = _pageRepository.GetPageById(id.Value);
            if(page == null)
            {
                return NotFound();
            }
            ViewBag.Groupid = new SelectList(groupPageRepository.GetAllGroups(), "GroupId", "GroupTitle", page.GroupId);
            return View(page);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("PageId,Title,GroupId,ShortDiscreption,Text,visite,ImageName,ShowInSlider,CreateDate,Tags")] Page page, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                _pageRepository.UpdatePage(page);
                _pageRepository.save();           
                return RedirectToAction("Index");
            }
            ViewBag.GroupId = new SelectList(_db.Groups, "GroupId", "GroupTitle", page.GroupId);
                return View(page);    
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }
            return View(page);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = _pageRepository.GetPageById(id);
            if (!string.IsNullOrEmpty(page.ImageName))
            {
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "PageImage", page.ImageName);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);

                }
            }
            _pageRepository.DeletePage(id);
            _pageRepository.save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
