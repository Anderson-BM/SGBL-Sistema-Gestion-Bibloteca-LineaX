using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SGBL.Infrastructure.Identity.Entities;

namespace SGBL.Infrastructure.Identity.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
     public IdentityContext(DbContextOptions<IdentityContext> options) : base(options){ }
    

    protected override void OnModelCreating(ModelBuilder builder)
       { 
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity");

            builder.Entity<IdentityUser>().ToTable("User");

            builder.Entity<IdentityRole>().ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        }
       }
}
