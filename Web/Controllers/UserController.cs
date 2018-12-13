using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TransportSystems.Web.Models;

namespace TransportSystems.Web.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();

            return PartialView("_AddUser", model);
        }
    }
}
