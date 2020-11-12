using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.BL.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();

         Task<Product> GetProduct(int id);
       
         Task<Product> UpdateProduct(Product entity);

         Task<Product> DeleteProduct(int id);

        Task<Product> CreateProduct(Product entity);

    }
}
