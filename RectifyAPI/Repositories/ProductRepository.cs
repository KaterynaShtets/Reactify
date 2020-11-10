using DAL.EFCore;
using Shared.Models;

namespace ReactifyAPI.Repositories
{
    public class ProductRepository : Repository<Product, ApplicationDbContext>
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
    }
}