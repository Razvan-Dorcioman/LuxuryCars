using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxuryCars.Models.Entities
{
  public class Product
  {
    public int Id { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public int Price { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public long KM { get; set; }
    public string Engine { get; set; }
    public string FuelType { get; set; }
    public int HorsePower { get; set; }
    public DateTime Manufactoring { get; set; }
    public User User { get; set; }
  }
}
