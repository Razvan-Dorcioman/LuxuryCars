using LuxuryCars.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuxuryCars.ViewModels
{
    public class ProductViewModel
    {   
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Engine { get; set; }
        [Required]
        public string FuelType { get; set; }
        [Required]
        public int HorsePower { get; set; }
        [Required]
        public long KM { get; set; }
        [Required]
        public DateTime Manufactoring { get; set; }
        public User User { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
