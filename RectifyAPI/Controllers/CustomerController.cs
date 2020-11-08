using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace ReactifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAllCustomers")]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            return await _service.GetAllCustomers();
        }

        [HttpGet(/*"{id}"*/)]
        [Route("getCustomerById")]
        public async Task<ActionResult<Customer>> GetOne(int id)
        {
            return await _service.GetCustomer(id);
        }

        [HttpGet(/*"{id}"*/)]
        [Route("getCustomerByName")]
        public async Task<ActionResult<Customer>> GetCustomerByName(string name)
        {
            return await _service.ChooseCustomerByName(name);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> Update(Customer entity)
        {
            return await _service.UpdateCustomer(entity);
        }

        [HttpDelete(/*"{id}"*/)]
        [Route("deleteCustomer")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            return await _service.DeleteCustomer(id);
        }
    }
}
