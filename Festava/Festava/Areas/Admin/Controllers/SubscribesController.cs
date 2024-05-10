using Festava.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Festava.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SubscribesController : Controller
	{
		private readonly AppDbContext _db;
		private readonly IWebHostEnvironment _env;
		public SubscribesController(AppDbContext db, IWebHostEnvironment env)
		{
			_db = db;
			_env = env;

		}
		public async Task<IActionResult> Index()
		{
			var subscribers = await _db.Subscribes.OrderByDescending(x=>x.Id).ToListAsync();
			return View(subscribers);
		}
	}
}
