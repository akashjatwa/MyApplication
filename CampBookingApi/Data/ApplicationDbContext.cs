using Microsoft.EntityFrameworkCore;
using CampBookingApi.Models;

namespace CampBookingApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camp> Camps => Set<Camp>();
        public DbSet<Customer> Customers => Set<Customer>();
    }
}
