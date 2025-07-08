using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGBL.Core.Application.Interfaces.Repositories;
using SGBL.Infrastructure.Persistence.Context;
using SGBL.Infrastructure.Persistence.Repositories;

namespace SGBL.Infrastructure.Persistence
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ILibroRepository, LibroRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IGeneroRepository, GeneroRepository>();
            services.AddTransient<IPrestamoRepository, PrestamoRepository>();
            #endregion
        }
    }
}
