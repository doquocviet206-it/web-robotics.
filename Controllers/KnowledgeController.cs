using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class KnowledgeController : Controller
    {
        private readonly RoboticsDataService _data;
        public KnowledgeController(RoboticsDataService data) => _data = data;

        public IActionResult Index(string? category, string? level, string? search)
        {
            var articles = _data.GetKnowledgeArticles().AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                articles = articles.Where(a => a.Category.Contains(category, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(level) && level != "All")
            {
                articles = articles.Where(a => a.Level.Contains(level, System.StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.ToLower();
                articles = articles.Where(a => a.Title.ToLower().Contains(s) || 
                                               a.Summary.ToLower().Contains(s) || 
                                               a.Tags.Any(t => t.ToLower().Contains(s)));
            }

            ViewBag.CurrentCategory = category ?? "All";
            ViewBag.CurrentLevel = level ?? "All";
            ViewBag.CurrentSearch = search ?? "";

            return View(articles.ToList());
        }

        public IActionResult Detail(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            var article = _data.GetKnowledgeArticles().FirstOrDefault(a => a.Slug.Equals(id, System.StringComparison.OrdinalIgnoreCase));
            if (article == null) return NotFound();

            var related = _data.GetKnowledgeArticles().Where(a => a.Id != article.Id).Take(3).ToList();
            ViewBag.RelatedArticles = related;

            return View(article);
        }
    }
}


