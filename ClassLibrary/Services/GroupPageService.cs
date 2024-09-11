using ClassLibrary.Models;
using ClassLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GroupPageService : IGroupPageRepository
    {
        private readonly MyCmsContext myCmsContext ;

        public GroupPageService(MyCmsContext myCmsContext)
        {
            this.myCmsContext = myCmsContext;
        }

        public IEnumerable<GroupPage> GetAllGroups()
        {
            return myCmsContext.Groups;
        }

        public GroupPage GetGroupById(int groupId)
        {
            return myCmsContext.Groups.Find(groupId);
        }

        public bool InsertGroup(GroupPage groupPage)
        {
            try
            {
                myCmsContext.Groups.Add(groupPage);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateGroup(GroupPage groupPage)
        {
          try
            {
                myCmsContext.Entry(groupPage).State = EntityState.Modified;
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool DeleteGroup(int groupId)
        {
            try
            {
                var group = GetGroupById(groupId);
                DeleteGroup(group);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool DeleteGroup(GroupPage groupPage)
        {
            try
            {
                myCmsContext.Entry(groupPage).State = EntityState.Deleted;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void save()
        {
            myCmsContext.SaveChanges();
        }
        public void Dispose()
        {
        }

        public IEnumerable<ShowGroupsViewModel> GetGroupsForView()
        {
            return myCmsContext.Groups.Select(g => new ShowGroupsViewModel()
            {
                GroupId = g.GroupId,
                GroupTitle = g.GroupTitle,
                PageCount = g.Pages.Count,
            });

            
        }
    }
}
