using Festava.DAL;
using Festava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _db;
        public ArtistsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Artist> artists = await _db.Artists.ToListAsync();
            return View(artists);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Artist artist)
        {
            //DERS 27-NIN 8.ADDIMI BASQA YERE LAZIM OLSA YAZARSAN

            //bool isExist=await _db.Artists.AnyAsync(x=>x.Name==artist.Name);
            //if(isExist)
            //{
            //    ModelState.AddModelError("Name", "This artist is already exist!");
            //    return View();
            //}


            await _db.Artists.AddAsync(artist);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            Artist dbArtist = await _db.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (dbArtist == null) 
            {
                return BadRequest();
            }   
            return View(dbArtist);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Artist artist)
        {
            if (id == null)
            {
                return NotFound();
            }
            Artist dbArtist = await _db.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (dbArtist == null)
            {
                return BadRequest();
            }
            //bool isExist = await _db.Artists.AnyAsync(x => x.Name == artist.Name && x.Id!=id);
            //if (isExist)
            //{
            //    ModelState.AddModelError("Name", "This artist is already exist!");
            //    return View();
            //}
            dbArtist.Image= artist.Image;
            dbArtist.Name= artist.Name;
            dbArtist.Birthdate = artist.Birthdate;
            dbArtist.Music = artist.Music;
            dbArtist.YoutubeChannel=artist.YoutubeChannel;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Artist dbArtist = await _db.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (dbArtist == null)
            {
                return BadRequest();
            }
            return View(dbArtist);
        }
















    }
}
