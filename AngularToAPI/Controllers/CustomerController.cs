using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularToAPI.Models;
using AngularToAPI.ModelViews.users;
using AngularToAPI.Repository.Admin;
using AngularToAPI.Repository.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularToAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CustomerController : ControllerBase
    {
        private readonly IOrdersRepository _repo;

        public CustomerController(IOrdersRepository repo)
        {
            _repo = repo;
        }

        [Route("GetCustomers")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            
            return await _repo.GetCustomerAsync();
        }
        [Route("CustomerByid/{id}")]
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomerByid(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _repo.GetCustomerByidAsync(id);
            if (user != null)
            {
                return user;
            }
            return BadRequest();
        }

        [Route("EditCustomer")]
        [HttpPut]
        public async Task<ActionResult<Customer>> EditCustomer(Customer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var cust = await _repo.EditCustomerAsync(model);
            if (cust != null)
            {
                return cust;
            }
            return BadRequest();
        }

        [Route("AddCustomer")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var cust = await _repo.AddCustomerAsync(model);
            if (cust != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("DeleteCustomer")]
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            if (id =="")
            {
                return BadRequest();
            }

            var result = await _repo.DeleteCustomerAsync(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
