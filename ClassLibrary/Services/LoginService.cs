using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class LoginService : ILoginRepository
    {
        MyCmsContext _context;
        public LoginService(MyCmsContext context)
        {
            _context = context;
        }

        public bool IsExasit(string userName, string passward)
        {
            return _context.adminLogINs.Any(u => u.UserName == userName && u.Password == passward);
        }
    }
}
