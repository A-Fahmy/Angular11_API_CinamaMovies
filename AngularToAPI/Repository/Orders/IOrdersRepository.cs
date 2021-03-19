using AngularToAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularToAPI.Repository.Orders
{
    public interface IOrdersRepository
    {
        #region Customers
        Task<IEnumerable<Customer>> GetCustomerAsync();
        Task<Customer> GetCustomerByidAsync(string id);
        Task<Customer> EditCustomerAsync(Customer model);
        Task<Customer> AddCustomerAsync(Customer model);
        Task<bool> DeleteCustomerAsync(string id);
        #endregion


        #region Items
        Task<IEnumerable<Item>> GetItemAsync();
        Task<Item> GetItemByidAsync(string id);
        Task<Item> EditItemAsync(Item model);
        Task<Item> AddItemAsync(Item model);
        Task<bool> DeleteItemAsync(string id);
        #endregion


        #region Orders
        IActionResult GetOrderAsync();
        IActionResult GetOrderByidAsync(string id);
        Task<Order> EditOrderAsync(long id,Order model);
        //IActionResult AddOrderAsync(Order model);
        Task<Order> AddOrderAsync(Order model);
        Task<Order> DeleteOrderAsync(string id);
        #endregion


    }
}
