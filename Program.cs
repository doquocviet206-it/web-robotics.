using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using web_robotics.Data;

namespace web_robotics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            if (builder.Configuration["Database:Provider"] == "MySql")
            {
                builder.Services.AddDbContext<MySqlRoboticsDbContext>(options => options.UseMySQL(
                    builder.Configuration.GetConnectionString("MySqlDatabase")
                    ?? throw new InvalidOperationException("Configure ConnectionStrings:MySqlDatabase with User Secrets.")));
                builder.Services.AddScoped<RoboticsDbContext>(services => services.GetRequiredService<MySqlRoboticsDbContext>());
            }
            else
            {
            var connection = new SqliteConnectionStringBuilder(
                builder.Configuration.GetConnectionString("RoboticsDatabase")
                ?? "Data Source=App_Data/robotics.db");
            if (connection.DataSource != ":memory:")
            {
                connection.DataSource = Path.GetFullPath(connection.DataSource, builder.Environment.ContentRootPath);
                Directory.CreateDirectory(Path.GetDirectoryName(connection.DataSource)!);
            }
            builder.Services.AddDbContext<RoboticsDbContext>(options => options.UseSqlite(connection.ToString()));
            }
            builder.Services.AddScoped<Services.RoboticsDataService>();
            builder.Services.AddScoped<Services.RoboticsAssistantService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                DatabaseInitializer.Initialize(scope.ServiceProvider.GetRequiredService<RoboticsDbContext>());
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
