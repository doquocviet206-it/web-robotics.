using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_robotics.Data;
using web_robotics.Models;

namespace web_robotics.Controllers;

[Authorize(Roles = "Admin")]
[Route("quan-tri-noi-bo")]
public class AdminController(RoboticsDbContext db) : Controller
{
    [HttpGet("")]
    public IActionResult Index(string tab = "projects")
    {
        ViewBag.ActiveTab = tab;
        ViewBag.Projects = db.Projects.AsNoTracking().OrderByDescending(x => x.Id).ToList();
        ViewBag.Articles = db.Articles.AsNoTracking().OrderByDescending(x => x.Id).ToList();
        ViewBag.Publications = db.Publications.AsNoTracking().OrderByDescending(x => x.Year).ThenByDescending(x => x.Id).ToList();
        ViewBag.Documents = db.Documents.AsNoTracking().OrderByDescending(x => x.Id).ToList();
        return View();
    }

    [HttpPost("SaveProject")]
    [ValidateAntiForgeryToken]
    public IActionResult SaveProject(ProjectItem model, string? keyFeaturesText)
    {
        if (string.IsNullOrWhiteSpace(model.Title))
        {
            TempData["Error"] = "Tên dự án không được để trống.";
            return RedirectToAction(nameof(Index), new { tab = "projects" });
        }

        model.Slug = string.IsNullOrWhiteSpace(model.Slug) ? Slugify(model.Title) : model.Slug.Trim().ToLowerInvariant();
        model.IsCompletedProduct = model.Status == "Đã hoàn thành";
        model.KeyFeatures = SplitLines(keyFeaturesText);
        if (string.IsNullOrWhiteSpace(model.ImageUrl))
        {
            model.ImageUrl = "https://images.unsplash.com/photo-1485827404703-89b55fcc595e?auto=format&fit=crop&w=800&q=80";
        }

        if (model.Id == 0)
        {
            if (db.Projects.Any(x => x.Slug == model.Slug))
            {
                model.Slug = $"{model.Slug}-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            }
            db.Projects.Add(model);
            TempData["Success"] = $"Đã thêm dự án \"{model.Title}\".";
        }
        else
        {
            var existing = db.Projects.FirstOrDefault(x => x.Id == model.Id);
            if (existing == null)
            {
                TempData["Error"] = "Không tìm thấy dự án cần cập nhật.";
                return RedirectToAction(nameof(Index), new { tab = "projects" });
            }

            existing.Title = model.Title;
            existing.Slug = model.Slug;
            existing.Category = model.Category;
            existing.Status = model.Status;
            existing.IsCompletedProduct = model.IsCompletedProduct;
            existing.ShortDescription = model.ShortDescription;
            existing.DetailedDescription = model.DetailedDescription;
            existing.TechStack = model.TechStack;
            existing.Specifications = model.Specifications;
            existing.LeadResearcher = model.LeadResearcher;
            existing.Year = model.Year;
            existing.ImageUrl = model.ImageUrl;
            existing.KeyFeatures = model.KeyFeatures;
            TempData["Success"] = $"Đã cập nhật dự án \"{model.Title}\".";
        }

        db.SaveChanges();
        return RedirectToAction(nameof(Index), new { tab = "projects" });
    }

    [HttpPost("DeleteProject")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteProject(int id)
    {
        var item = db.Projects.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            db.Projects.Remove(item);
            db.SaveChanges();
            TempData["Success"] = $"Đã xóa dự án \"{item.Title}\".";
        }
        return RedirectToAction(nameof(Index), new { tab = "projects" });
    }

    [HttpPost("SaveArticle")]
    [ValidateAntiForgeryToken]
    public IActionResult SaveArticle(KnowledgeArticle model, string? tagsText)
    {
        if (string.IsNullOrWhiteSpace(model.Title))
        {
            TempData["Error"] = "Tiêu đề bài viết không được để trống.";
            return RedirectToAction(nameof(Index), new { tab = "articles" });
        }

        model.Slug = string.IsNullOrWhiteSpace(model.Slug) ? Slugify(model.Title) : model.Slug.Trim().ToLowerInvariant();
        model.Tags = SplitComma(tagsText);
        if (string.IsNullOrWhiteSpace(model.PublishedDate))
        {
            model.PublishedDate = DateTime.Now.ToString("dd/MM/yyyy");
        }
        if (model.ReadTimeMinutes <= 0) model.ReadTimeMinutes = 5;

        if (model.Id == 0)
        {
            if (db.Articles.Any(x => x.Slug == model.Slug))
            {
                model.Slug = $"{model.Slug}-{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            }
            db.Articles.Add(model);
            TempData["Success"] = $"Đã thêm bài viết \"{model.Title}\".";
        }
        else
        {
            var existing = db.Articles.FirstOrDefault(x => x.Id == model.Id);
            if (existing == null)
            {
                TempData["Error"] = "Không tìm thấy bài viết cần cập nhật.";
                return RedirectToAction(nameof(Index), new { tab = "articles" });
            }

            existing.Title = model.Title;
            existing.Slug = model.Slug;
            existing.Category = model.Category;
            existing.Level = model.Level;
            existing.Author = model.Author;
            existing.PublishedDate = model.PublishedDate;
            existing.ReadTimeMinutes = model.ReadTimeMinutes;
            existing.Summary = model.Summary;
            existing.ContentMarkdown = model.ContentMarkdown;
            existing.Tags = model.Tags;
            TempData["Success"] = $"Đã cập nhật bài viết \"{model.Title}\".";
        }

        db.SaveChanges();
        return RedirectToAction(nameof(Index), new { tab = "articles" });
    }

    [HttpPost("DeleteArticle")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteArticle(int id)
    {
        var item = db.Articles.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            db.Articles.Remove(item);
            db.SaveChanges();
            TempData["Success"] = $"Đã xóa bài viết \"{item.Title}\".";
        }
        return RedirectToAction(nameof(Index), new { tab = "articles" });
    }

    [HttpPost("SavePublication")]
    [ValidateAntiForgeryToken]
    public IActionResult SavePublication(ResearchPublication model)
    {
        if (string.IsNullOrWhiteSpace(model.Title))
        {
            TempData["Error"] = "Tiêu đề công bố không được để trống.";
            return RedirectToAction(nameof(Index), new { tab = "publications" });
        }

        if (model.Year <= 0) model.Year = DateTime.Now.Year;

        if (model.Id == 0)
        {
            db.Publications.Add(model);
            TempData["Success"] = $"Đã thêm công bố \"{model.Title}\".";
        }
        else
        {
            var existing = db.Publications.FirstOrDefault(x => x.Id == model.Id);
            if (existing == null)
            {
                TempData["Error"] = "Không tìm thấy công bố cần cập nhật.";
                return RedirectToAction(nameof(Index), new { tab = "publications" });
            }

            existing.Title = model.Title;
            existing.Authors = model.Authors;
            existing.JournalOrConference = model.JournalOrConference;
            existing.Year = model.Year;
            existing.Doi = model.Doi;
            existing.Abstract = model.Abstract;
            existing.PaperUrl = model.PaperUrl;
            existing.CitationRank = model.CitationRank;
            existing.Category = model.Category;
            TempData["Success"] = $"Đã cập nhật công bố \"{model.Title}\".";
        }

        db.SaveChanges();
        return RedirectToAction(nameof(Index), new { tab = "publications" });
    }

    [HttpPost("DeletePublication")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePublication(int id)
    {
        var item = db.Publications.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            db.Publications.Remove(item);
            db.SaveChanges();
            TempData["Success"] = $"Đã xóa công bố \"{item.Title}\".";
        }
        return RedirectToAction(nameof(Index), new { tab = "publications" });
    }

    [HttpPost("SaveDocument")]
    [ValidateAntiForgeryToken]
    public IActionResult SaveDocument(LabDocGuide model)
    {
        if (string.IsNullOrWhiteSpace(model.Title))
        {
            TempData["Error"] = "Tên tài liệu không được để trống.";
            return RedirectToAction(nameof(Index), new { tab = "documents" });
        }

        if (model.Id == 0)
        {
            db.Documents.Add(model);
            TempData["Success"] = $"Đã thêm tài liệu \"{model.Title}\".";
        }
        else
        {
            var existing = db.Documents.FirstOrDefault(x => x.Id == model.Id);
            if (existing == null)
            {
                TempData["Error"] = "Không tìm thấy tài liệu cần cập nhật.";
                return RedirectToAction(nameof(Index), new { tab = "documents" });
            }

            existing.Title = model.Title;
            existing.Category = model.Category;
            existing.FileSize = model.FileSize;
            existing.Version = model.Version;
            existing.Description = model.Description;
            existing.TargetAudience = model.TargetAudience;
            existing.DownloadOrViewUrl = model.DownloadOrViewUrl;
            TempData["Success"] = $"Đã cập nhật tài liệu \"{model.Title}\".";
        }

        db.SaveChanges();
        return RedirectToAction(nameof(Index), new { tab = "documents" });
    }

    [HttpPost("DeleteDocument")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteDocument(int id)
    {
        var item = db.Documents.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            db.Documents.Remove(item);
            db.SaveChanges();
            TempData["Success"] = $"Đã xóa tài liệu \"{item.Title}\".";
        }
        return RedirectToAction(nameof(Index), new { tab = "documents" });
    }

    private static List<string> SplitLines(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? new List<string>()
            : text.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();

    private static List<string> SplitComma(string? text) =>
        string.IsNullOrWhiteSpace(text)
            ? new List<string>()
            : text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();

    private static string Slugify(string input)
    {
        var chars = input.Trim().ToLowerInvariant()
            .Select(c => char.IsLetterOrDigit(c) ? c : '-')
            .ToArray();
        var raw = new string(chars);
        while (raw.Contains("--")) raw = raw.Replace("--", "-");
        return raw.Trim('-');
    }
}
