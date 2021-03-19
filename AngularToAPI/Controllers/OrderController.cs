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
    public class OrderController : ControllerBase
    {
        private readonly IOrdersRepository _repo;

        public OrderController(IOrdersRepository repo)
        {
            _repo = repo;
        }

        [Route("GetOrder")]
        [HttpGet]
        public IActionResult GetOrder()
        {
            return _repo.GetOrderAsync();
        }
        [Route("GetOrderByid/{id}")]
        [HttpGet]
        public IActionResult GetOrderByid(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _Order = _repo.GetOrderByidAsync(id);
            if (_Order != null)
            {
                return _Order;
            }
            return BadRequest();
        }

        [Route("EditOrder/{id}")]
        [HttpPut]
        public async Task<ActionResult<Order>> EditOrder(long id, Order model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var _order = await _repo.EditOrderAsync(id,model);
            if (_order != null)
            {
                return _order;
            }
            return BadRequest();
        }

        [Route("AddOrder")]
        [HttpPost]
        //public  IActionResult AddOrder(Order model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }
        //    var _order = _repo.AddOrderAsync(model);
        //    if (_order != null)
        //    {
        //        return Ok();
        //    }
        //    return BadRequest();
        //}
        public async Task<ActionResult<Order>> AddOrder(Order model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var _order = await _repo.AddOrderAsync(model);
            if (_order != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("DeleteOrder")]
        [HttpPost]
        public async Task<ActionResult<Order>> DeleteOrder(string id)
        {
            if (id == "")
            {
                return BadRequest();
            }

            var result = await _repo.DeleteOrderAsync(id);
            if (result!=null)
            {
                return Ok();
            }
            return BadRequest();
        }
       
    }
}
