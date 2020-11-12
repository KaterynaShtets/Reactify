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
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _customerRepository.Get(id);
        }

        public async Task<Customer> UpdateCustomer(Customer entity)
        {
            return await _customerRepository.Update(entity);
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            return await _customerRepository.Delete(id);
        }

        public async Task<Customer> ChooseCustomerByName(string companyName)
        {
            var interviews = await _customerRepository.GetAll();
            return interviews.FirstOrDefault(p => p.CompanyName.Equals(companyName));
        }
    }
}