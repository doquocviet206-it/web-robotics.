using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using web_robotics.Services;

namespace web_robotics.Controllers
{
    public class SearchSuggestion
    {
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = "bi-search";
    }
    public class SearchViewModel
    {
        public string Query { get; set; } = string.Empty;
        public string Filter { get; set; } = "all";
        public List<Models.ProjectItem> Projects { get; set; } = new();
        public List<Models.KnowledgeArticle> Articles { get; set; } = new();
        public List<Models.ResearchPublication> Publications { get; set; } = new();
        public List<Models.LabDocGuide> Docs { get; set; } = new();
        public int TotalMatches => Projects.Count + Articles.Count + Publications.Count + Docs.Count;
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

        [HttpGet]
        public IActionResult Suggest(string? q)
        {
            var query = q?.Trim() ?? string.Empty;
            var suggestions = new List<SearchSuggestion>();

            if (string.IsNullOrWhiteSpace(query))
            {
                suggestions.AddRange(new[]
                {
                    new SearchSuggestion { Title = "ROS 2", Category = "Từ khóa phổ biến", Url = "/Search?q=ROS+2", Icon = "bi-fire" },
                    new SearchSuggestion { Title = "SLAM", Category = "Từ khóa phổ biến", Url = "/Search?q=SLAM", Icon = "bi-fire" },
                    new SearchSuggestion { Title = "FOC BLDC", Category = "Từ khóa phổ biến", Url = "/Search?q=FOC", Icon = "bi-fire" },
                    new SearchSuggestion { Title = "Inverse Kinematics", Category = "Từ khóa phổ biến", Url = "/Search?q=Inverse+Kinematics", Icon = "bi-fire" }
                });

                foreach (var p in _data.GetProjects().Take(2))
                {
                    suggestions.Add(new SearchSuggestion
                    {
                        Title = p.Title,
                        Category = "Dự án",
                        Url = $"/Projects/Detail/{p.Slug}",
                        Icon = "bi-cpu"
                    });
                }

                foreach (var a in _data.GetKnowledgeArticles().Take(2))
                {
                    suggestions.Add(new SearchSuggestion
                    {
                        Title = a.Title,
                        Category = "Kiến thức",
                        Url = $"/Knowledge/Detail/{a.Slug}",
                        Icon = "bi-journal-code"
                    });
                }

                return Json(suggestions);
            }

            var lower = query.ToLower();

            suggestions.AddRange(_data.GetProjects()
                .Where(p => p.Title.ToLower().Contains(lower) ||
                            p.TechStack.ToLower().Contains(lower) ||
                            p.Category.ToLower().Contains(lower))
                .Take(3)
                .Select(p => new SearchSuggestion
                {
                    Title = p.Title,
                    Category = "Dự án",
                    Url = $"/Projects/Detail/{p.Slug}",
                    Icon = "bi-cpu"
                }));

            suggestions.AddRange(_data.GetKnowledgeArticles()
                .Where(a => a.Title.ToLower().Contains(lower) ||
                            a.Category.ToLower().Contains(lower) ||
                            a.Tags.Any(t => t.ToLower().Contains(lower)))
                .Take(3)
                .Select(a => new SearchSuggestion
                {
                    Title = a.Title,
                    Category = "Kiến thức",
                    Url = $"/Knowledge/Detail/{a.Slug}",
                    Icon = "bi-journal-code"
                }));

            suggestions.AddRange(_data.GetPublications()
                .Where(p => p.Title.ToLower().Contains(lower) ||
                            p.JournalOrConference.ToLower().Contains(lower) ||
                            p.Category.ToLower().Contains(lower))
                .Take(2)
                .Select(p => new SearchSuggestion
                {
                    Title = p.Title,
                    Category = "Công bố",
                    Url = $"/Search?q={Uri.EscapeDataString(p.Title)}&filter=research",
                    Icon = "bi-award"
                }));

            suggestions.AddRange(_data.GetLabDocs()
                .Where(d => d.Title.ToLower().Contains(lower) ||
                            d.Category.ToLower().Contains(lower))
                .Take(2)
                .Select(d => new SearchSuggestion
                {
                    Title = d.Title,
                    Category = "Tài liệu",
                    Url = "/Docs",
                    Icon = "bi-file-earmark-text"
                }));

            return Json(suggestions
                .GroupBy(s => s.Title, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.First())
                .Take(8)
                .ToList());
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

