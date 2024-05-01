using Festava.DAL;
using Festava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SchedulesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public SchedulesController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            List<Schedule>schedules= await _db.Schedules.Include(x=>x.Artist).ToListAsync();
            return View(schedules);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Artists = await _db.Artists.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Schedule schedule, int artistId)
        {
            ViewBag.Artists = await _db.Artists.ToListAsync();
            schedule.ArtistId= artistId;
            await _db.Schedules.AddAsync(schedule);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            Schedule dbSchedule = await _db.Schedules.FirstOrDefaultAsync(x => x.Id == id);
            if (dbSchedule == null)
            {
                return BadRequest();
            }
            ViewBag.Artists = await _db.Artists.ToListAsync();
            return View(dbSchedule);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, Schedule schedule, int artistId)
        {

            if (id == null)
            {
                return NotFound();
            }
            Schedule dbSchedule = await _db.Schedules.FirstOrDefaultAsync(x => x.Id == id);
            if (dbSchedule == null)
            {
                return BadRequest();
            }
            ViewBag.Artists = await _db.Artists.ToListAsync();



            dbSchedule.Day = schedule.Day;
            dbSchedule.Name = schedule.Name;
            dbSchedule.Time = schedule.Time;
            dbSchedule.ArtistId = artistId;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
