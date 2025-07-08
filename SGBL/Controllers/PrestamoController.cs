using Microsoft.AspNetCore.Mvc;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Prestamo;

namespace SGBL.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        public async Task<IActionResult> Index()
        {
            var prestamos = await _prestamoService.GetAllViewModel();
            return View(prestamos);
        }

        public async Task<IActionResult> Create()
        {
            return View(new SavePrestamoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePrestamoViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            await _prestamoService.Add(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Aprobar(int id)
        {
            await _prestamoService.AprobarPrestamoAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Rechazar(int id)
        {
            await _prestamoService.RechazarPrestamoAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Devolver(int id)
        {
            await _prestamoService.DevolverPrestamoAsync(id);
            return RedirectToAction("Index");
        }
    }
}
