using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using SGBL.Core.Application.Interfaces.Services;
using SGBL.Core.Application.ViewModels.Libro;
using SGBL.Models;

namespace SGBL.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly IGeneroService _generoService;
        private readonly IAuthorService _authorService;

        public HomeController(ILibroService libroService, IGeneroService generoService, IAuthorService authorService)
        { 
            _libroService = libroService;
            _generoService = generoService;
            _authorService = authorService;    
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
