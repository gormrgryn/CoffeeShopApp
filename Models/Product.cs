using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApp.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required (ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\(\):])+(.png)", ErrorMessage = "Incorrect img address")]
        [Required(ErrorMessage = "Incorrect img address")]
        public string Image { get; set; }
        [Required (ErrorMessage = "This field is required")]
        [Display(Name = "Drink Type")]
        public string DrinkType { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Required(ErrorMessage = "This field is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public decimal Calories { get; set; }
    }
}
