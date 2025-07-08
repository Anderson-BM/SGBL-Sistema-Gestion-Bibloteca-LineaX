using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.Services;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Core.Application.ViewModels.Prestamo;
using SGBL.Core.Domain.Enums;
using SGBL.Infrastructure.Identity.Entities;
using SGBL.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SGBL.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IGeneroService _generoService;
        private readonly IAuthorService _authorService;
        private readonly IPrestamoService _presetamoService;
        private readonly UserManager<ApplicationUser> _userManager;



        public HomeController(ILibroService libroService, IGeneroService generoService, IAuthorService authorService, IPrestamoService prestamoService, UserManager<ApplicationUser> userManager)
        { 
            _libroService = libroService;
            _generoService = generoService;
            _authorService = authorService;
            _presetamoService = prestamoService;
            _userManager = userManager;
        }

        //------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index(FilterLibroViewModel vm)
        {
            ViewBag.Genero = await _generoService.GetAllViewModel();
            ViewBag.Author = await _authorService.GetAllViewModel();
            return View(await _libroService.GetAllViewModelWithFilters(vm));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            try
            {
                // Obtener datos reales del sistema
                var libros = await _libroService.GetAllViewModel();
                var autores = await _authorService.GetAllViewModel();
                var generos = await _generoService.GetAllViewModel();

                // Pasar los datos a la vista
                ViewBag.TotalBooks = libros?.Count ?? 0;
                ViewBag.TotalAuthors = autores?.Count ?? 0;
                ViewBag.TotalGenres = generos?.Count ?? 0;

                return View();
            }
            catch (Exception ex)
            {
                // En caso de error, mostrar valores por defecto
                ViewBag.TotalBooks = 0;
                ViewBag.TotalAuthors = 0;
                ViewBag.TotalGenres = 0;

                return View();
            }
        }


        public async Task<IActionResult> DashboardUser()
        {
            try
            {
                // Obtener datos reales del sistema
                var libros = await _libroService.GetAllViewModel();
                var autores = await _authorService.GetAllViewModel();
                var generos = await _generoService.GetAllViewModel();

                // Pasar los datos a la vista
                ViewBag.TotalBooks = libros?.Count ?? 0;
                ViewBag.TotalAuthors = autores?.Count ?? 0;
                ViewBag.TotalGenres = generos?.Count ?? 0;

                return View();
            }
            catch (Exception ex)
            {
                // En caso de error, mostrar valores por defecto
                ViewBag.TotalBooks = 0;
                ViewBag.TotalAuthors = 0;
                ViewBag.TotalGenres = 0;

                return View();
            }
        }


        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Reservar(int id)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }

        //    var nuevoPrestamo = new SavePrestamoViewModel
        //    {
        //        LibroId = id,
        //      //  UsuarioId = user.Id,
        //        Estado = EstadoPrestamo.Pendiente,
        //        FechaSolicitud = DateTime.Now
        //    };

        //    await _presetamoService.Add(nuevoPrestamo);

        //    return RedirectToAction("Index", "Prestamo");
        //}





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
