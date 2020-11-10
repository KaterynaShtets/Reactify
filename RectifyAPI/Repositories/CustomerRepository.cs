using DAL.EFCore;
using Shared.Models;

namespace ReactifyAPI.Repositories
{
    public class CustomerRepository : Repository<Customer, ApplicationDbContext>
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }
    }
}
