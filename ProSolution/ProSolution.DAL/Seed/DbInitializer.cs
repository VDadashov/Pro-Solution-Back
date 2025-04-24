using Microsoft.Extensions.DependencyInjection;
using ProSolution.DAL.Contexts;
using ProSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProSolution.DAL.Seed
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await context.Database.MigrateAsync(); 

            if (!await context.Abouts.AnyAsync())
            {
                var about = new About
                {
                    Title = "haqqimizda",
                    Description = "haqqimizda haqqimizda haqqimizda haqqimizda haqqimizda haqqimizda ",
                    ImagePath = null 
                };

                context.Abouts.Add(about);
                await context.SaveChangesAsync();
            }
        }
    }
}
