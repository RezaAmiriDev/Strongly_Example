using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PageService : IPageRepository
    {
        private readonly MyCmsContext _db;
        public PageService(MyCmsContext db)
        { _db = db; }
      
        public IEnumerable<Page> GetAllPage()
        {
            try
            {
                return _db.Pages.ToList();
            }catch (Exception ex)
            {
                throw;

            }
           
        }
       
        
        public Page GetPageById(int PageId)
        {
            return _db.Pages.Find(PageId);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                _db.Pages.Add(page);
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                _db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public bool DeletePage(int PageId)
        {
            try
            {
                var _page = GetPageById(PageId);
                DeletePage(_page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePage(Page page)
        {
            try
            {
                _db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void save()
        {
            _db.SaveChanges();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return _db.Pages.OrderByDescending(p => p.visite).Take(take);
        }

        public IEnumerable<Page> PageInSlider()
        {
            return _db.Pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return _db.Pages.OrderByDescending(o => o.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroupId(int groupId)
        {
            return _db.Pages.Where(p => p.GroupId == groupId);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<Page> SearchPage(string search)
        {
            return _db.Pages.Where(p => p.Title.Contains(search) || p.ShortDiscreption.Contains(search) ||
            p.Tags.Contains(search) || p.Text.Contains(search)).Distinct();
        }
    }
}
