using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class SearchViewModel
    {
        public string Query { get; set; } = string.Empty;
        public string Filter { get; set; } = "all";
        public List<Models.ProjectItem> Projects { get; set; } = new();
        public List<Models.KnowledgeArticle> Articles { get; set; } = new();
        public List<Models.ResearchPublication> Publications { get; set; } = new();
        public List<Models.LabMember> Members { get; set; } = new();
        public List<Models.LabDocGuide> Docs { get; set; } = new();
        public int TotalMatches => Projects.Count + Articles.Count + Publications.Count + Members.Count + Docs.Count;
    }

    public class ChatRequest
    {
        public string Message { get; set; } = string.Empty;
    }

    public class SearchController : Controller
    {
        private readonly RoboticsAssistantService _assistantService;

        private readonly RoboticsDataService _data;

        public SearchController(RoboticsAssistantService assistantService, RoboticsDataService data)
        {
            _assistantService = assistantService;
            _data = data;
        }

        public IActionResult Index(string? q, string? filter)
        {
            var query = q?.Trim() ?? string.Empty;
            filter = string.IsNullOrWhiteSpace(filter) ? "all" : filter.ToLower();

            var vm = new SearchViewModel
            {
                Query = query,
                Filter = filter
            };

            if (!string.IsNullOrWhiteSpace(query))
            {
                var lower = query.ToLower();

                if (filter == "all" || filter == "projects")
                {
                    vm.Projects = _data.GetProjects()
                        .Where(p => p.Title.ToLower().Contains(lower) || 
                                    p.ShortDescription.ToLower().Contains(lower) || 
                                    p.TechStack.ToLower().Contains(lower) ||
                                    p.Category.ToLower().Contains(lower))
                        .ToList();
                }

                if (filter == "all" || filter == "knowledge")
                {
                    vm.Articles = _data.GetKnowledgeArticles()
                        .Where(a => a.Title.ToLower().Contains(lower) || 
                                    a.Summary.ToLower().Contains(lower) || 
                                    a.Tags.Any(t => t.ToLower().Contains(lower)) ||
                                    a.Category.ToLower().Contains(lower))
                        .ToList();
                }

                if (filter == "all" || filter == "research")
                {
                    vm.Publications = _data.GetPublications()
                        .Where(p => p.Title.ToLower().Contains(lower) || 
                                    p.Authors.ToLower().Contains(lower) || 
                                    p.Abstract.ToLower().Contains(lower) ||
                                    p.JournalOrConference.ToLower().Contains(lower))
                        .ToList();
                }

                if (filter == "all" || filter == "members")
                {
                    vm.Members = _data.GetMembers()
                        .Where(m => m.Name.ToLower().Contains(lower) || 
                                    m.Specialization.ToLower().Contains(lower) || 
                                    m.Role.ToLower().Contains(lower))
                        .ToList();
                }

                if (filter == "all" || filter == "docs")
                {
                    vm.Docs = _data.GetLabDocs()
                        .Where(d => d.Title.ToLower().Contains(lower) || 
                                    d.Description.ToLower().Contains(lower) || 
                                    d.Category.ToLower().Contains(lower))
                        .ToList();
                }
            }

            return View(vm);
        }

        [HttpPost]
        public IActionResult Chat([FromBody] ChatRequest? request)
        {
            var msg = request?.Message ?? string.Empty;
            var result = _assistantService.ProcessQuery(msg);
            return Json(result);
        }
    }
}

