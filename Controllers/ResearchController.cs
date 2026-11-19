using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class ResearchController : Controller
    {
        private readonly RoboticsDataService _data;
        public ResearchController(RoboticsDataService data) => _data = data;

        public IActionResult Index(string? category, int? year)
        {
            var publications = _data.GetPublications().AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                publications = publications.Where(p => p.Category.Contains(category, System.StringComparison.OrdinalIgnoreCase));
            }

            if (year.HasValue && year.Value > 0)
            {
                publications = publications.Where(p => p.Year == year.Value);
            }

            ViewBag.CurrentCategory = category ?? "All";
            ViewBag.CurrentYear = year ?? 0;

            return View(publications.ToList());
        }
    }
}


