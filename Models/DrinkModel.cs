using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApp.Models
{
    public class DrinkModel
    {
        [Key]
        public string Name { get; set; }
        public string Image { get; set; }

        [Column(TypeName = "decimal(18, 2")]
        public decimal Price { get; set; }
        public decimal Calories { get; set; }
        public string Ingridients { get; set; }
    }
}