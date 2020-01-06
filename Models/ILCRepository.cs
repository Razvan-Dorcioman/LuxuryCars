using LuxuryCars.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxuryCars.Models
{
    public interface ILCRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(string id);
        bool UpdateUser(User user);
        bool DeleteUser(string id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByBrand(string brand);
        Product GetProductById(int id);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string username, int id);
        void AddOrder(Order newOrder);
        bool SaveAll();
        void AddEntity(object model);
    }
}
