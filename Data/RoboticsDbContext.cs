using Microsoft.EntityFrameworkCore;
using web_robotics.Models;

namespace web_robotics.Data;

public class RoboticsDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<LabMember> Members => Set<LabMember>();
    public DbSet<ProjectItem> Projects => Set<ProjectItem>();
    public DbSet<ResearchPublication> Publications => Set<ResearchPublication>();
    public DbSet<KnowledgeArticle> Articles => Set<KnowledgeArticle>();
    public DbSet<LabDocGuide> Documents => Set<LabDocGuide>();
    public DbSet<DatabaseSeedState> SeedHistory => Set<DatabaseSeedState>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectItem>().HasIndex(x => x.Slug).IsUnique();
        modelBuilder.Entity<KnowledgeArticle>().HasIndex(x => x.Slug).IsUnique();
        modelBuilder.Entity<ResearchPublication>().HasIndex(x => x.Year);
        modelBuilder.Entity<ProjectItem>().HasIndex(x => x.Category);
        modelBuilder.Entity<KnowledgeArticle>().HasIndex(x => x.Category);
        modelBuilder.Entity<LabDocGuide>().HasIndex(x => x.Category);
    }
}

public class DatabaseSeedState
{
    public int Id { get; set; }
}
