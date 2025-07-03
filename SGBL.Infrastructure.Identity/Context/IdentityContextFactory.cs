using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SGBL.Infrastructure.Identity.Context;

public class IdentityContextFactory : IDesignTimeDbContextFactory<IdentityContext>
{
    public IdentityContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-UH1LS5T\\SQLEXPRESS;Database=SGBL;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=False");

        return new IdentityContext(optionsBuilder.Options);
    }

}
