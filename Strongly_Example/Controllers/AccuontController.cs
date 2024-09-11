using ClassLibrary;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Strongly_Example.Controllers
{
    public class AccuontController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        MyCmsContext _db;
        public AccuontController(ILoginRepository loginRepository, MyCmsContext db)
        {
            _loginRepository = loginRepository;
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if(ModelState.IsValid)
            {
                if(_loginRepository.IsExasit(login.UserName, login.Password))
                {

                }
                else
                {
                    ModelState.AddModelError("UserName","Not Found pussy");
                }
            }
            return View(login);
        }
    }
}
