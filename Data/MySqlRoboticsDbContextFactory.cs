using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace web_robotics.Data;

public class MySqlRoboticsDbContextFactory : IDesignTimeDbContextFactory<MySqlRoboticsDbContext>
{
    public MySqlRoboticsDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>(optional: true).AddEnvironmentVariables().Build();
        return new MySqlRoboticsDbContext(new DbContextOptionsBuilder<MySqlRoboticsDbContext>()
            .UseMySQL(configuration.GetConnectionString("MySqlDatabase")
                ?? throw new InvalidOperationException("Configure ConnectionStrings:MySqlDatabase.")) .Options);
    }
}
