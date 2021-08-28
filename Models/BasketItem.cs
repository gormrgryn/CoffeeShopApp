using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApp.Models
{
    public interface IBasketEntity
    {
        int BasketLineID { get; set; }
        int Quantity { get; set; }
    }
    public class BasketItem : IBasketEntity
    {
        [Key]
        public int BasketLineID { get; set; }
        
        public int Quantity { get; set; }

        public int ProductID { get; set; }
    }
    public class BasketLine : IBasketEntity
    {
        public int BasketLineID { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
    }
}
