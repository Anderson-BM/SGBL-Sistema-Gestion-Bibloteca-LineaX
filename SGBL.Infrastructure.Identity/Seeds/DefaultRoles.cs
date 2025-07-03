using Microsoft.AspNetCore.Identity;
using SGBL.Core.Application.Enums;
using SGBL.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> UserManager, RoleManager<IdentityRole> roleManager)
        {
            Console.WriteLine("➡️ Creando roles por defecto...");

            await roleManager.CreateAsync(new IdentityRole(Roles.superAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admi.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));

            Console.WriteLine("✅ Roles creados exitosamente.");

        }
    }
}
