using Festava.DAL;
using Festava.Helpers;
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
            schedule.ArtistId = artistId;
            await _db.Schedules.AddAsync(schedule);
            await _db.SaveChangesAsync();


            // Retrieve the artist details
            var artist = await _db.Artists.FindAsync(artistId);

            // Compose email message
            var message = $"New schedule created for {artist.Name} on {schedule.Day}.";
            var subject = "New Schedule Notification";

            // Send email to all subscribers
            var subscribes = await _db.Subscribes.ToListAsync();
            foreach (var sub in subscribes)
            {
                await Helper.SendMailAsync(subject, message, sub.Email);
            }

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



        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Schedule dbSchedule = await _db.Schedules.Include(x => x.Artist).FirstOrDefaultAsync(x => x.Id == id);
            if (dbSchedule == null)
            {
                return BadRequest();
            }
            return View(dbSchedule);
        }


        public async Task<IActionResult> Activity(int? id)
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
            if (dbSchedule.IsDeactive)
            {
                dbSchedule.IsDeactive = false;
            }
            else
            {
                dbSchedule.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }
}
