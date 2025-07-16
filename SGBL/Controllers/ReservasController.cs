using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Reservas;
using SGBL.Infrastructure.Identity.Entities;

namespace SGBL.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IReservasService _reservaService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservasController(IReservasService reservaService, UserManager<ApplicationUser> userManager)
        {
            _reservaService = reservaService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var reservas = await _reservaService.GetAll();
            return View(reservas);
        }

        [Authorize]
        public async Task<IActionResult> Create(int libroId)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = new SaveReservasViewModel { LibroId = libroId, UsuarioId = user.Id };
            await _reservaService.Add(model);
            TempData["mensaje"] = "Reserva realizada con éxito.";
            return RedirectToAction("Index");
        }
    }
}
