using System.Threading.Tasks;
using System.Web.Mvc;

namespace TrackPerformanceWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Task.WaitAll(Task.Delay(1000));
            return View();
        }

        public ActionResult About()
        {
            Task.WaitAll(Task.Delay(200));
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            Task.WaitAll(Task.Delay(500));
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}