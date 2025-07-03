using Microsoft.AspNetCore.Identity;
using SGBL.Core.Application.Enums;
using SGBL.Infrastructure.Identity.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGBL.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            Console.WriteLine("➡️ Iniciando creación de usuario BASIC...");

            var existingUser = await userManager.FindByEmailAsync("basicuser@email.com");

            if (existingUser != null)
            {
                Console.WriteLine("ℹ️ El usuario 'basicuser@email.com' ya existe. No se creará.");
                return;
            }

            var defaultUser = new ApplicationUser
            {
                UserName = "basicuser",
                Email = "basicuser@email.com",
                FirstName = "Jonh",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await userManager.CreateAsync(defaultUser, "123$$word!");

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"❌ Error creando usuario BASIC: {error.Description}");
                }
                return;
            }

            await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());

            Console.WriteLine("✅ Usuario BASIC creado exitosamente.");
        }
    }
}
