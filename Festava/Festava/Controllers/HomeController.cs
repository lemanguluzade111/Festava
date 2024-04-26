using System.Diagnostics;
using System.Text.RegularExpressions;
using Festava.DAL;
using Festava.Helpers;
using Festava.Models;
using Festava.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Title>  titles;
            List<About> abouts;
            List<Artist> artists;
            List<Price> prices;

            HomeVM homeVM = new HomeVM
            {
                Titles = _db.Titles.ToList(),
                About = _db.Abouts.FirstOrDefault(),
                Artists= _db.Artists.ToList(),
                Prices=_db.Prices.ToList()


            };


   




            return View(homeVM);



            
        }



        public async Task<IActionResult> Subscribe(string email)

        {

            if (email == null)

            {
              return Content("Email bos ola bilmez");
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = regex.Match(email);

            if (!match.Success)

            {
                return Content("Email deyil");
            }

            else
                {
               Subscribe subscribe = new Subscribe
                {
                  Email = email,
                };

                bool isExist = await _db.Subscribes.AnyAsync(x => x.Email == email);

                if (isExist)

                {
                    return Content("Email artiq movcuddur");
                }

                await _db.Subscribes.AddAsync(subscribe);

                await _db.SaveChangesAsync();

            }

            return Content("Ok");

        }



    }
 }

