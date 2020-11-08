using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> ChooseCustomerByName(string name);
        Task<Customer> GetCustomer(int id);
        Task<Customer> UpdateCustomer(Customer entity);
        Task<Customer> DeleteCustomer(int id);
    }
}
