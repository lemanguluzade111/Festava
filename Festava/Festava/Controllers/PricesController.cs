using Festava.DAL;
using Festava.Models;
using Festava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Controllers
{
    public class PricesController : Controller
    {
        private readonly AppDbContext _db;
        public PricesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Price> prices;
            HomeVM homeVM = new HomeVM
            {

                Prices = await _db.Prices.ToListAsync()

            };

            return View(homeVM);


        }
    }
}
