using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly RoboticsDataService _data;
        public ProjectsController(RoboticsDataService data) => _data = data;

        public IActionResult Index(string? category, string? status, string? search)
        {
            var projects = _data.GetProjects().AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                projects = projects.Where(p => p.Category.Contains(category, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                projects = projects.Where(p => p.Status.Equals(status, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.ToLower();
                projects = projects.Where(p => p.Title.ToLower().Contains(s) || 
                                               p.ShortDescription.ToLower().Contains(s) || 
                                               p.TechStack.ToLower().Contains(s));
            }

            ViewBag.CurrentCategory = category ?? "All";
            ViewBag.CurrentStatus = status ?? "All";
            ViewBag.CurrentSearch = search ?? "";

            return View(projects.ToList());
        }

        public IActionResult Completed()
        {
            var projects = _data.GetProjects().Where(p => p.IsCompletedProduct).ToList();
            ViewBag.Title = "Sản Phẩm Đã Hoàn Thành & Chuyển Giao Công Nghệ";
            return View("Completed", projects);
        }

        public IActionResult Detail(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            var project = _data.GetProjects().FirstOrDefault(p => p.Slug.Equals(id, System.StringComparison.OrdinalIgnoreCase));
            if (project == null)
            {
                return NotFound();
            }

            var related = _data.GetProjects().Where(p => p.Id != project.Id).Take(3).ToList();
            ViewBag.RelatedProjects = related;

            return View(project);
        }
    }
}


