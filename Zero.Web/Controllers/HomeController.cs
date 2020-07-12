using System.Web.Mvc;

namespace Zero.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}