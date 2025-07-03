using Microsoft.Extensions.DependencyInjection;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SGBL.Core.Application
{
    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<ILibroService, LibroService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IGeneroService, GeneroService>();
            #endregion
        }
    }
}