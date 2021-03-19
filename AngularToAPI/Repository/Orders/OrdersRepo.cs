using AngularToAPI.Models;
using AngularToAPI.ModelViews.users;
using AngularToAPI.Repository.Orders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace AngularToAPI.Repository.Admin
{
    public class OrdersRepo : IOrdersRepository
    {
        private readonly ApplicationDb _db;
        public OrdersRepo(ApplicationDb db)
        {
            _db = db;
        }
        #region Customers
        //
        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            
            return await _db.Customer.ToListAsync();
        }
        public async Task<Customer> GetCustomerByidAsync(string id)
        {
            if (id == null)
            {
                return null;
            }
            var cust = await _db.Customer.FirstOrDefaultAsync(x => x.CustomerID == int.Parse(id));
            if (cust == null)
            {
                return null;
            }
            return cust;
        }

        public async Task<Customer> EditCustomerAsync(Customer model)
        {
            if (model == null || model.CustomerID < 1)
            {
                return null;
            }
            var cust = await _db.Customer.FirstOrDefaultAsync(x => x.CustomerID == model.CustomerID);
            if (cust == null)
            {
                return null;
            }
            _db.Customer.Attach(cust);
            cust.Name = model.Name;
            //_db.Entry(cust).Property(x => x.Name).IsModified = true;
            _db.Entry(cust).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return cust;
        }

        public async Task<Customer> AddCustomerAsync(Customer model)
        {
            var cust = new Customer
            {
                Name = model.Name,
            };
            _db.Customer.Add(cust);
            await _db.SaveChangesAsync();
            return cust;
        }
        public async Task<bool> DeleteCustomerAsync(string id)
        {
            var catId = int.Parse(id);
            var cust = await _db.Customer.FirstOrDefaultAsync(x => x.CustomerID == catId);
            if (cust != null)
            {
                _db.Customer.Remove(cust);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;

            }

        }
        #endregion

        #region Items
        //
        public async Task<IEnumerable<Item>> GetItemAsync()
        {
            return await _db.Item.ToListAsync();
        }
        public async Task<Item> GetItemByidAsync(string id)
        {
            if (id == null)
            {
                return null;
            }
            var cust = await _db.Item.FirstOrDefaultAsync(x => x.ItemID == int.Parse(id));
            if (cust == null)
            {
                return null;
            }
            return cust;
        }

        public async Task<Item> EditItemAsync(Item model)
        {
            if (model == null || model.ItemID < 1)
            {
                return null;
            }
            var _item = await _db.Item.FirstOrDefaultAsync(x => x.ItemID == model.ItemID);
            if (_item == null)
            {
                return null;
            }
            _db.Item.Attach(_item);
            _item.Name = model.Name;
            _item.Price = model.Price;
            //_db.Entry(cust).Property(x => x.Name).IsModified = true;
            _db.Entry(_item).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return _item;
        }

        public async Task<Item> AddItemAsync(Item model)
        {
            var _item = new Item
            {
                Name = model.Name,
                Price= model.Price
            };
            _db.Item.Add(_item);
            await _db.SaveChangesAsync();
            return _item;
        }
        public async Task<bool> DeleteItemAsync(string id)
        {
            var catId = int.Parse(id);
            var _item = await _db.Item.FirstOrDefaultAsync(x => x.ItemID == catId);
            if (_item != null)
            {
                _db.Item.Remove(_item);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;

            }

        }
        #endregion

        #region Orders
        public  IActionResult GetOrderAsync()
        {
            var result = (from a in _db.Order
                          join b in _db.Customer on a.CustomerID equals b.CustomerID
                          select new
                          {
                              a.OrderID,
                              a.OrderNo,
                              Customer = b.Name,
                              a.PMethod,
                              a.GTotal
                          }).ToList();

            return new ObjectResult(result);
        }
        public IActionResult GetOrderByidAsync(string id)
        {
            var _id = int.Parse(id);
            var order = (from a in _db.Order
                         where a.OrderID == _id

                         select new
                         {
                             a.OrderID,
                             a.OrderNo,
                             a.CustomerID,
                             a.PMethod,
                             a.GTotal,
                             DeletedOrderItemIDs = ""
                         }).FirstOrDefault();

            var orderDetails = (from a in _db.OrderItem
                                join b in _db.Item on a.ItemID equals b.ItemID
                                where a.OrderID == _id
                                select new
                                {
                                    a.OrderID,
                                    a.OrderItemID,
                                    a.ItemID,
                                    ItemName = b.Name,
                                    b.Price,
                                    a.Quantity,
                                    Total = a.Quantity * b.Price
                                }).ToList();

            return new ObjectResult(new { order, orderDetails });
        }
        public async Task<Order> EditOrderAsync(long id, Order model)
        {
            if (id != model.OrderID)
            {
                return null;
            }
            var _Order = await _db.Order.FirstOrDefaultAsync(x => x.OrderID == model.OrderID);
            if (_Order == null)
            {
                return null;
            }
            _db.Order.Attach(_Order);
            _db.Entry(_Order).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return _Order;
        }

        //public IActionResult AddOrderAsync(Order model)
        //{




        //    try
        //    {
        //        //Order table

        //        var _Order = new Order
        //        {
        //            CustomerID = model.CustomerID,
        //            GTotal = model.GTotal,
        //            OrderID = model.OrderID,
        //            OrderNo = model.OrderNo,
        //            PMethod = model.PMethod
        //        };

        //        _db.Order.Add(_Order);

        //        //OrderItems table
        //        foreach (var item in model.OrderItems)
        //        {
        //            var _OrderItems = new OrderItem
        //            {
        //                OrderID = item.OrderID,
        //                OrderItemID = item.OrderItemID,
        //                ItemID = item.ItemID,
        //                Quantity = item.Quantity
        //            };
        //            _db.OrderItem.Add(_OrderItems);
        //        }
        //        _db.SaveChangesAsync();
        //        return new ObjectResult("OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task<Order> AddOrderAsync(Order model)
        {
            try
            {
                //Order table

                var _Order = new Order
                {
                    CustomerID = model.CustomerID,
                    GTotal = model.GTotal,
                    OrderNo = model.OrderNo,
                    PMethod = model.PMethod
                };

                _db.Order.Add(_Order);
                await _db.SaveChangesAsync();
                long _orderid = await _db.Order.MaxAsync(x=> x.OrderID);

                
                //OrderItems table
                foreach (var item in model.OrderItems)
                {
                    var _OrderItems = new OrderItem
                    {
                        OrderID = _orderid,
                        ItemID = item.ItemID,
                        Quantity = item.Quantity
                    };
                    _db.OrderItem.Add(_OrderItems);
                }
                await _db.SaveChangesAsync();
                return _Order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Order> DeleteOrderAsync(string id)
        {
            var catId = int.Parse(id);
            var _order = await _db.Order.FirstOrDefaultAsync(x => x.OrderID == catId);
            if (_order == null)
            {
                return null;
            }
            _db.Order.Remove(_order);
            await _db.SaveChangesAsync();
            return _order;
        }

     

        #endregion
    }
}
