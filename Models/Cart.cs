using System.Linq;
using System.Collections.Generic;

namespace CoffeeShopApp.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
                .Where(l => l.Product == product)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(
                    new CartLine { Product = product, Quantity = quantity }
                );
            } else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveItem(Product product) => lineCollection.RemoveAll(l => l.Product == product);
        public IEnumerable<CartLine> Lines => lineCollection;
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}