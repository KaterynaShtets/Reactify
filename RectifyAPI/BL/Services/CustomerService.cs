using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using ReactifyAPI.Repositories;
using Shared.Models;

namespace BL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _repository.GetAll();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<Customer> UpdateCustomer(Customer entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<Customer> ChooseCustomerByName(string companyName)
        {
            var interviews = await _repository.GetAll();
            return interviews.FirstOrDefault(p => p.CompanyName.Equals(companyName));
        }
    }
}