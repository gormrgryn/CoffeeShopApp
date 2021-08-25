using System.Linq;
using System.Collections.Generic;

namespace CoffeeShopApp.Models
{
    public class Basket
    {
        private List<BasketItem> lineCollection = new List<BasketItem>();

        public void AddItem(Product product, int quantity)
        {
            BasketItem line = lineCollection
                .Where(l => l.Product.ProductID == product.ProductID)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(
                    new BasketItem { Product = product, Quantity = quantity }
                );
            } else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveItem(Product product) =>
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        public IEnumerable<BasketItem> Lines => lineCollection;
    }
    public class BasketItem
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
