using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LuxuryCars.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string ProductModel { get; set; }
        public string ProductBrand { get; set; }
        public string ProductEngine { get; set; }
        public string ProductFuelType { get; set; }
        public int ProductHorsePower { get; set; }
        public DateTime ProductManufactoring { get; set; }

    }
}
