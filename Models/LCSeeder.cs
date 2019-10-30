using LuxuryCars.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LuxuryCars.Models
{
    public class LCSeeder
    {
        private readonly LCContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private readonly UserManager<User> _userManager;

        public LCSeeder(LCContext ctx, IWebHostEnvironment hosting, UserManager<User> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            // Seed the Main User
            User user = await _userManager.FindByEmailAsync("razvan@gmail.com");
            if (user == null)
            {
                user = new User()
                {
                    Email = "razvan@gmail.com",
                    UserName = "Razvan"
                };

                var result = await _userManager.CreateAsync(user, "P@ssword01");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create user in Seeding");
                }
            }

            if (!_ctx.Products.Any())
            {
                // Need to create sample data
                var filepath = Path.Combine(_hosting.ContentRootPath, "Models/cars.json");
                var json = File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
          {
            new OrderItem()
            {
              Product = products.First(),
              Quantity = 5,
              UnitPrice = products.First().Price
            }
          };
                }

                _ctx.SaveChanges();

            }
        }
    }
}
