using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrePopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
        
    }

    private static void SeedData(AppDbContext? context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("--> Seeding Data...");
            
            context.Platforms.AddRange(
                new Platform() { Name = "Dotnet6 Auth App", Publisher = "BuildIT", Cost = "Free" },
            new Platform() { Name = "SQL Server Express", Publisher = "BuildIT", Cost = "Free" },
            new Platform() { Name = "FileStock", Publisher = "BuildIT", Cost = "Free" }
                );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We already have data");
        }
    }
}