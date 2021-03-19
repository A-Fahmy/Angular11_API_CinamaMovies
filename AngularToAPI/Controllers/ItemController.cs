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
    public class ItemController : ControllerBase
    {
        private readonly IOrdersRepository _repo;

        public ItemController(IOrdersRepository repo)
        {
            _repo = repo;
        }

        [Route("GetItems")]
        [HttpGet]
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _repo.GetItemAsync();
        }
        [Route("GetItemByid/{id}")]
        [HttpGet]
        public async Task<ActionResult<Item>> GetItemByid(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _item = await _repo.GetItemByidAsync(id);
            if (_item != null)
            {
                return _item;
            }
            return BadRequest();
        }

        [Route("EditItem")]
        [HttpPut]
        public async Task<ActionResult<Item>> EditItem(Item model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var _item = await _repo.EditItemAsync(model);
            if (_item != null)
            {
                return _item;
            }
            return BadRequest();
        }

        [Route("AddItem")]
        [HttpPost]
        public async Task<IActionResult> AddItem(Item model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var _item = await _repo.AddItemAsync(model);
            if (_item != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("DeleteItem")]
        [HttpPost]
        public async Task<IActionResult> DeleteItem(string id)
        {
            if (id == "")
            {
                return BadRequest();
            }

            var result = await _repo.DeleteItemAsync(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
