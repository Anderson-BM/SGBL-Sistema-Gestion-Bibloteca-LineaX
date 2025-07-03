using Microsoft.AspNetCore.Mvc;

namespace SGBL.Controllers
{
    public class CatalogoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
