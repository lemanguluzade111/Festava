using Festava.DAL;
using Festava.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricesController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public PricesController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            List<Price> prices = await _db.Prices.ToListAsync();
            return View(prices);
          
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create(Price price)
        {
            await _db.Prices.AddAsync(price);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Price dbPrice = await _db.Prices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPrice == null)
            {
                return BadRequest();
            }
            return View(dbPrice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, Price price)
        {
            if (id == null)
            {
                return NotFound();
            }
            Price dbPrice = await _db.Prices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPrice == null)
            {
                return BadRequest();
            }
            dbPrice.Name = price.Name;
            dbPrice.Cost = price.Cost;
            dbPrice.Title = price.Title;
            dbPrice.Discount = price.Discount;
            dbPrice.Features = price.Features;
            dbPrice.Button = price.Button;

            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Price dbPrice = await _db.Prices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPrice == null)
            {
                return BadRequest();
            }
            return View(dbPrice);
        }


        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Price dbPrice = await _db.Prices.FirstOrDefaultAsync(x => x.Id == id);
            if (dbPrice == null)
            {
                return BadRequest();
            }
            if (dbPrice.IsDeactive)
            {
                dbPrice.IsDeactive = false;
            }
            else
            {
                dbPrice.IsDeactive = true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }
}
