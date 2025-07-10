using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SGBL.Core.Application;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.Interfaces.ServiceS;
using SGBL.Core.Application.Services;
using SGBL.Infrastructure.Identity.Context;
using SGBL.Infrastructure.Identity.Entities;
using SGBL.Infrastructure.Identity.Seeds;
using SGBL.Infrastructure.Identity.Services;
using SGBL.Infrastructure.Persistence;
using SGBL.Infrastructure.Persistence;
using SGBL.Infrastructure.Persistence.Context;
using SGBL.Infrastructure.Shared.Service;

//using SGBL.Infrastructure.Shared.Service; 
using System.Configuration;
using WebApp.SGBL.Middlewares;
using static Org.BouncyCastle.Math.EC.ECCurve;

var builder = WebApplication.CreateBuilder(args);

// Registra todos los servicios aquí:
builder.Services.AddControllersWithViews();



builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()  // Tu clase DbContext
    .AddDefaultTokenProviders();




builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // O el nombre correcto de tu conexión




builder.Services.AddSession();
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<LoginAuthorize>();
builder.Services.AddScoped<ValidateUserSession>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<ValidateUserSession, ValidateUserSession>();
//builder.Services.AddScoped<IWebAppAccountService, WebAppAccountService>(); 
//-------------------------------------------------------------------------------------------------------------
// Agregar servicios
//builder.Services.AddApplicationLayer(_config); // Solo uno de estos es necesario, revisa si es duplicado
//builder.Services.AddSharedInfrastructure(_config);
//-------------------------------------------------------------------------------------------------------------


// Después que ya registraste todo:
var app = builder.Build();
//WebApplication app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//        // ?? Ejecuta primero roles
//        await DefaultRoles.SeedAsync(userManager, roleManager);

//        // ? Luego los usuarios
//        await DefaultSuperAdmiUser.SeedAsync(userManager, roleManager);
//        await DefaultBasicUser.SeedAsync(userManager, roleManager);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"? Error sembrando datos: {ex.Message}");
//        throw; // Lanza para que lo veas
//    }
//}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Crear roles si no existen
        var roles = new[] { "superAdmin", "Admi", "Basic", "Biblotecario" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Crear usuario admin si no existe
        var adminEmail = "admin@email.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            var user = new ApplicationUser
            {
                UserName = "adminuser",
                Email = adminEmail,
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, "123$$word!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "superAdmin");
                await userManager.AddToRoleAsync(user, "Admi");

                Console.WriteLine("? Usuario admin creado.");
            }
            else
            {
                Console.WriteLine("? Error al crear el usuario admin:");
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"- {error.Description}");
                }
            }
        }
        else
        {
            Console.WriteLine("?? Usuario admin ya existe.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"? Error durante la creación del admin: {ex.Message}");
    }
}



//-------------------------------------------------------------------------------------------------------------
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//        await DefaultRoles.SeedAsync(userManager, roleManager);
//        await DefaultSuperAdmiUser.SeedAsync(userManager, roleManager);
//        await DefaultBasicUser.SeedAsync(userManager, roleManager);
//    }
//    catch (Exception ex)
//    {
//        // Manejo de excepciones (puedes agregar logging aquí)
//    }
//}
//-------------------------------------------------------------------------------------------------------------

//await app.Services.RunAsyncSeed();

app.UseHttpsRedirection();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}")
    .WithStaticAssets();

//app.Run();
await app.RunAsync();