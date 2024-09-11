using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories
{
    public interface IGroupPageRepository: IDisposable
    {
        IEnumerable<GroupPage> GetAllGroups();
        GroupPage GetGroupById(int GroupId);
        bool InsertGroup(GroupPage groupPage);
        bool UpdateGroup(GroupPage groupPage);
        bool DeleteGroup(int GroupId);
        void save();

        IEnumerable<ShowGroupsViewModel> GetGroupsForView();
    }
}
