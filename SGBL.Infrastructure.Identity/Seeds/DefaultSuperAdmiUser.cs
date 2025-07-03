using Microsoft.AspNetCore.Identity;
using SGBL.Core.Application.Enums;
using SGBL.Infrastructure.Identity.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGBL.Infrastructure.Identity.Seeds
{
    public static class DefaultSuperAdmiUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            Console.WriteLine("➡️ Iniciando creación de usuario SUPERADMIN...");

            var existingUser = await userManager.FindByEmailAsync("Eduandy@email.com");

            if (existingUser != null)
            {
                Console.WriteLine("ℹ️ El usuario 'Eduandy@email.com' ya existe. No se creará.");
                return;
            }

            var defaultUser = new ApplicationUser
            {
                UserName = "EICA",
                Email = "Eduandy@email.com",
                FirstName = "Eduandy",
                LastName = "Cruz Abreu"
              
            };

            var result = await userManager.CreateAsync(defaultUser, "Eduandy1234$!");

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"❌ Error creando usuario SUPERADMIN: {error.Description}");
                }
                return;
            }

            await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
            await userManager.AddToRoleAsync(defaultUser, Roles.Admi.ToString());
            await userManager.AddToRoleAsync(defaultUser, Roles.superAdmin.ToString());

            Console.WriteLine("✅ Usuario SUPERADMIN creado exitosamente.");
        }
    }
}
