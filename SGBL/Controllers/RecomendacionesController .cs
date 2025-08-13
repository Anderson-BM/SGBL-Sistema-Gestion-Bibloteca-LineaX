using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.Services;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Infrastructure.Identity.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SGBL.Controllers
{
    [Authorize]
    public class RecomendacionesController : Controller
    {
        private readonly IReservasService _reservaService;
        private readonly ILibroService _libroService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecomendacionesController(
            IReservasService reservaService,
            ILibroService libroService,
            UserManager<ApplicationUser> userManager)
        {
            _reservaService = reservaService;
            _libroService = libroService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            // 1️⃣ Obtener todas las reservas del usuario actual
            var reservasUsuario = await _reservaService.GetAll();
            var generosReservados = reservasUsuario
                .Where(r => r.UsuarioId == user.Id)
                .Select(r => r.TituloLibro)
                .Distinct()
                .ToList();

            var todosLibros = await _libroService.GetAllViewModel();
            List<LibroViewModel> recomendaciones;

            // 2️⃣ Si el usuario tiene reservas, recomendar libros del mismo género
            if (generosReservados.Any())
            {
                recomendaciones = todosLibros
                    .Where(l => generosReservados.Contains(l.GeneroName))
                    .OrderByDescending(l => l.Id)
                    .Take(7) // Máximo 7 libros
                    .ToList();
            }
            else
            {
                // 3️⃣ Si no tiene reservas, recomendar libros recientes
                recomendaciones = todosLibros
                    .OrderByDescending(l => l.Id)
                    .Take(7)
                    .ToList();
            }

            ViewBag.NombreUsuario = user.UserName;
            return View(recomendaciones);
        }
    }
}