using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories
{
    public interface IPageRepository :IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(int PageId);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(int PageId);
        void save();

        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> PageInSlider();
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> ShowPageByGroupId(int GroupId);
        IEnumerable<Page> SearchPage(string search);
    }
}
