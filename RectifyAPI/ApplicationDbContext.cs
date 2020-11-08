using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ReactifyAPI
{
    public class ApplicationDbContext : IdentityDbContext<Customer, IdentityRole<int>, int>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Indicators> Indicators { get; set; }
        public DbSet<IndicatorsInfo> IndicatorsInfo { get; set; }
        public DbSet<TesterUser> TesterUsers { get; set; }
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
