using Microsoft.AspNetCore.Mvc;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Author;

namespace SGBL.Controllers
{
    //  [Authorize(Roles ="Admi")]
    public class AuthorController : Controller
    {
      private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _authorService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("SaveAuthor", new SaveAutorViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAutorViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveAuthor", vm);
            }

            await _authorService.Add(vm);
            return RedirectToRoute(new { controller = "Author", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveAuthor", await _authorService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAutorViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveAuthor", vm);
            }

            await _authorService.Update(vm, vm.Id);
            return RedirectToRoute(new { controller = "Author", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _authorService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {       

            await _authorService.Delete(id);
            return RedirectToRoute(new { controller = "Author", action = "Index" });
        }
    }
}
