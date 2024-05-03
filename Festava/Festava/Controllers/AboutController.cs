using Festava.DAL;
using Festava.Models;
using Festava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<About> abouts;
            HomeVM homeVM = new HomeVM
            {

                About = await _db.Abouts.FirstOrDefaultAsync()

            };

            return View(homeVM);


        }
        
    }
}
