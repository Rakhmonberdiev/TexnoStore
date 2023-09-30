using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexnoStore.Core.Entities;

namespace TexnoStore.Infrastructure.Data
{
    public class SeedIdentityUser
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var admin = await userManager.FindByEmailAsync("Admin@gmail.com");
                if (admin == null)
                {
                    admin = new AppUser
                    {
                        DisplayName = "Jamoliddin",
                        UserName = "Jam@test.com",
                        Email = "Jam@test.com",
                        Address = new Address
                        {
                            FirstName = "Jamoliddin",
                            LastName = "Rakhmonberdiyev",
                            Street = "Baht 34",
                            City = "Tashkent",
                            State = "TSH",
                            ZipCode = "111444"
                        }
                    
                    };
                    await userManager.CreateAsync(admin, "Admin123*");
                }
                var role = new IdentityRole
                {
                    Name = Admin
                };
                await roleManager.CreateAsync(role);
                await userManager.AddToRoleAsync(admin, Admin);
            }
        }
        private const string Admin = "Admin";
    }
}
