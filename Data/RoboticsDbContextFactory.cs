using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace web_robotics.Data;

public class RoboticsDbContextFactory : IDesignTimeDbContextFactory<RoboticsDbContext>
{
    public RoboticsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        var options = new DbContextOptionsBuilder<RoboticsDbContext>()
            .UseSqlite(configuration.GetConnectionString("RoboticsDatabase"))
            .Options;
        return new RoboticsDbContext(options);
    }
}
