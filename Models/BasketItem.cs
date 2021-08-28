using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApp.Models
{
    // public class Basket
    // {
    //     private List<BasketItem> lineCollection = new List<BasketItem>();

    //     public void AddItem(Product product, int quantity)
    //     {
    //         BasketItem line = lineCollection
    //             .FirstOrDefault(l => product.ProductID == l.Product.ProductID);
    //         if (line == null)
    //         {
    //             lineCollection.Add(new BasketItem {
    //                 Product = product,
    //                 Quantity = quantity
    //             });
    //         } else
    //         {
    //             line.Quantity += quantity;
    //         }
    //     }
    //     public void RemoveItem(Product product) =>
    //         lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
    //     public IEnumerable<BasketItem> Lines => lineCollection;
    // }
    public class BasketItem
    {
        [Key]
        public int BasketLineID { get; set; }
        
        public int Quantity { get; set; }
        public int ProductID { get; set; }
    }
}
