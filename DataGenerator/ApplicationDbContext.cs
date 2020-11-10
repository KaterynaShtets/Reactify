using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace DataGenerator
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Indicators> Indicators { get; set; }
        public DbSet<IndicatorsInfo> IndicatorsInfo { get; set; }
        public DbSet<TesterUser> TesterUsers { get; set; }
        public DbSet<Product> Products { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-OQ106UV\SQLEXPRESS;Initial Catalog=ReactifyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
