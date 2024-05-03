using Festava.DAL;
using Festava.Models;
using Festava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Controllers
{
    
    public class SchedulesController : Controller
    {
        private readonly AppDbContext _db;
        public SchedulesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Schedule> schedules;
            HomeVM homeVM = new HomeVM
            {

                Schedules = await _db.Schedules.Where(x => !x.IsDeactive).Include(x => x.Artist).ToListAsync()

            };

            return View(homeVM);


        }

    

    }
}
