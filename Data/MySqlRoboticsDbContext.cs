using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace web_robotics.Data;

public class MySqlRoboticsDbContext(DbContextOptions<MySqlRoboticsDbContext> options) : RoboticsDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                property.SetColumnType("longtext");
        }
        modelBuilder.Entity<Models.ProjectItem>().Property(x => x.Slug).HasColumnType("varchar(191)").HasMaxLength(191);
        modelBuilder.Entity<Models.KnowledgeArticle>().Property(x => x.Slug).HasColumnType("varchar(191)").HasMaxLength(191);
        modelBuilder.Entity<Models.ProjectItem>().Property(x => x.Category).HasColumnType("varchar(191)").HasMaxLength(191);
        modelBuilder.Entity<Models.KnowledgeArticle>().Property(x => x.Category).HasColumnType("varchar(191)").HasMaxLength(191);
        modelBuilder.Entity<Models.LabDocGuide>().Property(x => x.Category).HasColumnType("varchar(191)").HasMaxLength(191);
        ConfigureList(modelBuilder.Entity<Models.LabMember>().Property(x => x.Highlights));
        ConfigureList(modelBuilder.Entity<Models.ProjectItem>().Property(x => x.KeyFeatures));
        ConfigureList(modelBuilder.Entity<Models.KnowledgeArticle>().Property(x => x.Tags));
    }

    private static void ConfigureList(Microsoft.EntityFrameworkCore.Metadata.Builders.PropertyBuilder<List<string>> property)
    {
        property.HasConversion(
            value => JsonSerializer.Serialize(value, (JsonSerializerOptions?)null),
            value => JsonSerializer.Deserialize<List<string>>(value, (JsonSerializerOptions?)null) ?? new());
        property.HasColumnType("longtext");
        property.Metadata.SetValueComparer(new ValueComparer<List<string>>(
            (a, b) => a!.SequenceEqual(b!),
            value => value.Aggregate(0, (hash, item) => HashCode.Combine(hash, item.GetHashCode())),
            value => value.ToList()));
    }
}
