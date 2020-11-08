using DAL.EFCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.Repositories
{
    public class ProductRepository : Repository<Product, ApplicationDbContext>
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
    }
}