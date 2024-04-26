using Microsoft.AspNetCore.Mvc;

namespace Festava.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
