using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProSolution.Core.Entities;
using System;
using System.Threading.Tasks;

namespace ProSolution.BL.Helpers
{
    public static class RoleSeeder
    {
        public static async Task SeedDefaultUsersAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            var superAdmin = await userManager.FindByNameAsync("superadmin");

            if (superAdmin == null)
            {
                var user = new User
                {
                    UserName = "superadmin",
                    Email = "superadmin@mail.com",
                    FirstName = "Super",
                    LastName = "Admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "SuperAdmin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
        }
    }
}
