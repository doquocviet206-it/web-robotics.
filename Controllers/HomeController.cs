using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            var members = _data.GetMembers();
            ViewBag.Members = members;
            return View();
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


