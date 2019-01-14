using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AreasController : Controller
    {
        public ActionResult Areas()
        {
            ViewBag.Title = "Areas Page";

            return View();
        }
    }
}