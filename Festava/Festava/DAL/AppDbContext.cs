using Festava.Models;
using Microsoft.EntityFrameworkCore;

namespace Festava.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Title> Titles { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }


    }
}
