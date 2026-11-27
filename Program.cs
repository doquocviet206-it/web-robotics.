using Microsoft.AspNetCore.Authentication.Cookies;
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
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/quan-tri-noi-bo/dang-nhap";
                    options.AccessDeniedPath = "/quan-tri-noi-bo/tu-choi";
                    options.ExpireTimeSpan = TimeSpan.FromHours(8);
                });
            builder.Services.AddAuthorization();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                DatabaseInitializer.Initialize(scope.ServiceProvider.GetRequiredService<RoboticsDbContext>());
            }

            var adminPort = builder.Configuration.GetValue<int?>("AdminPortal:Port") ?? 5192;

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseWhen(ctx => ctx.Connection.LocalPort != adminPort, branch => branch.UseHttpsRedirection());
            app.UseStaticFiles();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var isAdminPort = context.Connection.LocalPort == adminPort;
                var isAdminPath = context.Request.Path.StartsWithSegments("/quan-tri-noi-bo", StringComparison.OrdinalIgnoreCase);

                if (!isAdminPort && isAdminPath)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    return;
                }

                if (isAdminPort && !isAdminPath)
                {
                    if (context.Request.Path == "/")
                    {
                        context.Response.Redirect("/quan-tri-noi-bo");
                        return;
                    }

                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    return;
                }

                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
