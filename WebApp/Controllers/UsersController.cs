using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Users()
        {
            return View();
        }
    }
}