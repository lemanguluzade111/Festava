using Microsoft.AspNetCore.Mvc;

namespace Festava.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
