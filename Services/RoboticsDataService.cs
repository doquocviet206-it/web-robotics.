using Microsoft.EntityFrameworkCore;
using web_robotics.Data;
using web_robotics.Models;

namespace web_robotics.Services;

public class RoboticsDataService(RoboticsDbContext db)
{
    public List<LabMember> GetMembers() => db.Members.AsNoTracking().OrderBy(x => x.Id).ToList();
    public List<ProjectItem> GetProjects() => db.Projects.AsNoTracking().OrderBy(x => x.Id).ToList();
    public List<ResearchPublication> GetPublications() => db.Publications.AsNoTracking().OrderByDescending(x => x.Year).ThenBy(x => x.Id).ToList();
    public List<KnowledgeArticle> GetKnowledgeArticles() => db.Articles.AsNoTracking().OrderBy(x => x.Id).ToList();
    public List<LabDocGuide> GetLabDocs() => db.Documents.AsNoTracking().OrderBy(x => x.Id).ToList();

    public LabOverviewViewModel GetLabOverview() => new()
    {
        TotalProjects = db.Projects.Count(),
        CompletedProducts = db.Projects.Count(x => x.IsCompletedProduct),
        ActivePublications = db.Publications.Count(),
        MembersCount = db.Members.Count(),
        FeaturedProjects = db.Projects.AsNoTracking().OrderBy(x => x.Id).Take(3).ToList(),
        RecentPublications = db.Publications.AsNoTracking().OrderByDescending(x => x.Year).ThenBy(x => x.Id).Take(3).ToList(),
        LatestArticles = db.Articles.AsNoTracking().AsEnumerable().OrderByDescending(x => DateOnly.ParseExact(x.PublishedDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)).ThenBy(x => x.Id).Take(3).ToList(),
        CoreMembers = db.Members.AsNoTracking().OrderBy(x => x.Id).Take(4).ToList()
    };
}

