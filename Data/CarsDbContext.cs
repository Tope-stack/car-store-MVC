using CarsMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsMVC.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
    }
}
