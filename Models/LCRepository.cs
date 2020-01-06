using LuxuryCars.Controllers;
using LuxuryCars.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxuryCars.Models
{
    public class LCRepository : ILCRepository
    {
        private readonly LCContext _ctx;
        private readonly ILogger<LCRepository> _logger;

        public LCRepository(LCContext ctx, ILogger<LCRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users
                .OrderBy(p => p.UserName)
                .ToList();
        }

        public User GetUserById(string id)
        {
            return _ctx.Users
                .FirstOrDefault(u => u.Id.Equals(id));
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _ctx.Update(user);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
                throw;
            }
        }

        public bool DeleteUser(string id)
        {
            try
            {
                User user = this.GetUserById(id);
                _ctx.Remove(user);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
                throw;
            }
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public void AddOrder(Order newOrder)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            props["OrderNumber"] = newOrder.OrderNumber;
            props["OrderDate"] = newOrder.OrderDate.ToString();
            props["User"] = newOrder.User.UserName;
            var i = 0;
            var totalPrice = 0;
            
            // Convert new products to lookup of product
            foreach (var item in newOrder.Items)
            {
                i++;
                item.Product = _ctx.Products.Find(item.Product.Id);
                props["Brand" + i] = item.Product.Brand;
                totalPrice += item.UnitPrice * item.Quantity;
            }

            props["TotalPrice"] = totalPrice.ToString();

            AddEntity(newOrder);

            TelemetryController.SendEvent("Order placed", props);

        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {

                return _ctx.Orders
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .ToList();

            }
            else
            {
                return _ctx.Orders
                           .ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {

                return _ctx.Orders
                           .Where(o => o.User.UserName == username)
                           .Include(o => o.Items)
                           .ThenInclude(i => i.Product)
                           .ToList();

            }
            else
            {
                return _ctx.Orders
                           .Where(o => o.User.UserName == username)
                           .ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("GetAllProducts was called");

                return _ctx.Products
                           .OrderBy(p => p.Title)
                           .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders
                       .Include(o => o.Items)
                       .ThenInclude(i => i.Product)
                       .Where(o => o.Id == id && o.User.UserName == username)
                       .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByBrand(string brand)
        {
            return _ctx.Products
                       .Where(p => p.Brand == brand)
                       .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
