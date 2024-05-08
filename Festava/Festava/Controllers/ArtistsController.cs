using Festava.DAL;
using Festava.Models;
using Festava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _db;
        public ArtistsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ArtistsCount=await _db.Artists.Where(x=>!x.IsDeactive).CountAsync();

            List<Artist> artists;
            HomeVM homeVM = new HomeVM
            {

                Artists = await _db.Artists.Where(x => !x.IsDeactive).OrderByDescending(x=>x.Id).Take(4).ToListAsync()

            };

            return View(homeVM);

      
        }


        
        public async Task<IActionResult> LoadMore(int skipCount)
        {
            int count = await _db.Artists.Where(x => !x.IsDeactive).CountAsync();
            if (count<=skipCount)
            {
                return Content("DO NOT EVEN TRY");
            }
            List <Artist>artists = await _db.Artists.Where(x => !x.IsDeactive).OrderByDescending(x=>x.Id).Skip(skipCount).Take(4).ToListAsync();  
            return PartialView("_LoadMoreArtistsPartial", artists);
        }
    }

}