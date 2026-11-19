using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class MembersController : Controller
    {
        private readonly RoboticsDataService _data;
        public MembersController(RoboticsDataService data) => _data = data;

        public IActionResult Index(string? role)
        {
            var members = _data.GetMembers().AsQueryable();

            if (!string.IsNullOrWhiteSpace(role) && role != "All")
            {
                members = members.Where(m => m.Role.Contains(role, System.StringComparison.OrdinalIgnoreCase) || 
                                             m.Specialization.Contains(role, System.StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.CurrentRole = role ?? "All";
            return View(members.ToList());
        }

        public IActionResult Detail(int id)
        {
            var member = _data.GetMembers().FirstOrDefault(m => m.Id == id);
            if (member == null) return NotFound();

            var relatedPublications = _data.GetPublications()
                .Where(p => p.Authors.Contains(member.Name.Split('.').Last().Trim()))
                .ToList();

            ViewBag.Publications = relatedPublications;
            return View(member);
        }
    }
}


