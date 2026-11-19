using Microsoft.EntityFrameworkCore;
using web_robotics.Services;

namespace web_robotics.Data;

public static class DatabaseInitializer
{
    public static void Initialize(RoboticsDbContext db)
    {
        db.Database.Migrate();
        using var transaction = db.Database.BeginTransaction();
        if (!db.SeedHistory.Any(x => x.Id == 1))
        {
            db.Members.AddRange(RoboticsMockData.GetMembers());
            db.Projects.AddRange(RoboticsMockData.GetProjects());
            db.Publications.AddRange(RoboticsMockData.GetPublications());
            db.Articles.AddRange(RoboticsMockData.GetKnowledgeArticles());
            db.Documents.AddRange(RoboticsMockData.GetLabDocs());
            db.SeedHistory.Add(new DatabaseSeedState { Id = 1 });
            db.SaveChanges();
        }
        transaction.Commit();
    }
}

