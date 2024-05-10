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

                Prices = await _db.Prices.Where(x => !x.IsDeactive).ToListAsync()

            };

            return View(homeVM);


        }



        [HttpPost]
        public IActionResult Index(int priceId)
        {
            // Logic to handle ticket purchase
            // You can retrieve the selected price by its ID (priceId) and process the purchase

            return RedirectToAction("Index", "Confirmation"); // Redirect to a confirmation page after purchase
        }
    }
}
