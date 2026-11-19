using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class DocsController : Controller
    {
        private readonly RoboticsDataService _data;
        public DocsController(RoboticsDataService data) => _data = data;

        public IActionResult Index(string? category)
        {
            var docs = _data.GetLabDocs().AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                docs = docs.Where(d => d.Category.Contains(category, System.StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.CurrentCategory = category ?? "All";
            return View(docs.ToList());
        }
    }
}


