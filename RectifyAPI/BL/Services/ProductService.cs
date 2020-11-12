using ReactifyAPI.BL.Interfaces;
using ReactifyAPI.Repositories;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ReactifyAPI.BL.Services
{
    public class ProductService: IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProduct(Product entity)
        {
            return await _productRepository.Add(entity);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.Get(id);
        }

        public async Task<Product> UpdateProduct(Product entity)
        {
            return await _productRepository.Update(entity);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return await _productRepository.Delete(id);
        }

    }
}
