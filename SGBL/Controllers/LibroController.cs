using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGBL.Core.Application.Enums;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Libro;

namespace SGBL.Controllers
{
  //  [Authorize(Roles ="Basic")]
    public class LibroController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IAuthorService _authorService;
        private readonly IGeneroService _generoService;

        public LibroController(ILibroService libroService, IAuthorService authorService, IGeneroService generoService)
        {
            _libroService = libroService;
            _authorService = authorService;
            _generoService = generoService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _libroService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            SaveLibroViewModel vm = new();
            vm.Author = await _authorService.GetAllViewModel();
            vm.Genero = await _generoService.GetAllViewModel();
            return View("SaveLibro", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveLibroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Author = await _authorService.GetAllViewModel();
                vm.Genero = await _generoService.GetAllViewModel();
                return View("SaveLibro", vm);

               
            }

            await _libroService.Add(vm);
            return RedirectToRoute(new { controller = "Libro", action = "Index" });  // revisar el netflix aqui debe de estar el errorr
        }

        public async Task<IActionResult> Edit(int id)
        {
            SaveLibroViewModel vm = await _libroService.GetByIdSaveViewModel(id);
            vm.Author = await _authorService.GetAllViewModel();
            vm.Genero = await _generoService.GetAllViewModel();
            return View("SaveLibro", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveLibroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Author = await _authorService.GetAllViewModel();
                vm.Genero = await _generoService.GetAllViewModel();
                return View("SaveLibro", vm);

               
            }

            await _libroService.Update(vm, vm.Id);
            return RedirectToRoute(new { controller = "Libro", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _libroService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {

            await _libroService.Delete(id);
            return RedirectToRoute(new { controller = "Libro", action = "Index" });
        }
    }
}
