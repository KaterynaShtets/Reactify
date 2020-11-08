using DAL.EFCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.Repositories
{
    public class CustomerRepository : Repository<Customer, ApplicationDbContext>
    {
        public CustomerRepository(ApplicationDbContext context) : base(context) { }
    }
}
