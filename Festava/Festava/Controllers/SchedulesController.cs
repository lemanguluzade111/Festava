using Microsoft.AspNetCore.Mvc;

namespace Festava.Controllers
{
    public class SchedulesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
