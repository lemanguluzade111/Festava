using System.Drawing;
using Festava.DAL;
using Festava.Helpers;
using Festava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace Festava.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArtistsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public ArtistsController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;

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
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(Artist artist)
        {
            //DERS 27-NIN 8.ADDIMI BASQA YERE LAZIM OLSA YAZARSAN

            //bool isExist=await _db.Artists.AnyAsync(x=>x.Name==artist.Name);
            //if(isExist)
            //{
            //    ModelState.AddModelError("Name", "This artist is already exist!");
            //    return View();
            //}

            #region SAVE IMAGE 
            if (artist.Photo == null)
            {
                ModelState.AddModelError("Photo", "Image cannot be null");
                return View();
            }

            if (!artist.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Please select image type");
                return View();
            }
            if (artist.Photo.IsOlder1Mb())
            {
                ModelState.AddModelError("Photo", "Max 1 Mb");
                return View();
            }
            string folder = Path.Combine(_env.WebRootPath, "images", "artists");
            artist.Image = await artist.Photo.SaveFileAsync(folder);
            #endregion


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
        [ValidateAntiForgeryToken]

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

            #region SAVE IMAGE
            if (artist.Photo != null)
            {
                if (!artist.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Please select image type");
                    return View();
                }
                if (artist.Photo.IsOlder1Mb())
                {
                    ModelState.AddModelError("Photo", "MAX 1 Mb");
                    return View();
                }
                string folder = Path.Combine(_env.WebRootPath, "images", "artists");
                artist.Image = await artist.Photo.SaveFileAsync(folder);
                string path = Path.Combine(_env.WebRootPath, folder, dbArtist.Image);
                if (System.IO.File.Exists(path)) ;
                {
                    System.IO.File.Delete(path);
                }
                dbArtist.Image = artist.Image;
            }

           
          
        
            #endregion

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



        public async Task<IActionResult> Delete(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]

        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Artist dbArtist=await _db.Artists.FirstOrDefaultAsync(x=>x.Id==id);
            if(dbArtist == null)
            {
                return BadRequest();
            }
            dbArtist.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activity(int? id)
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
            if (dbArtist.IsDeactive)
            {
                dbArtist.IsDeactive = false;
            }
            else
            {
                dbArtist.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }



















        }
    }
