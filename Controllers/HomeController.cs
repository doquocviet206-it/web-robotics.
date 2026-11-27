using Microsoft.AspNetCore.Mvc;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoboticsDataService _data;
        public HomeController(RoboticsDataService data) => _data = data;

        public IActionResult Index()
        {
            var overview = _data.GetLabOverview();
            return View(overview);
        }

        public IActionResult About()
        {
            return RedirectToAction(nameof(Index), null, null, "about-lab");
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}


