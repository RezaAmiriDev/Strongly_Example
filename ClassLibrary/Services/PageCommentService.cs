using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{


    public class PageCommentService : IPageCommentRepository
    {
        private readonly MyCmsContext db;
        public PageCommentService(MyCmsContext context)
    {
        db = context;
    }

        public IEnumerable<PageComment> GetCommentByNewsId(int pageId)
        {
            return db.Commens.Where(c => c.PageId == pageId);
        }
        public bool AddComment(PageComment comment)
        {

            try
            {
                db.Commens.Add(comment);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                throw;
            }
        }

    }
}
