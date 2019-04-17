using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models.Entities
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        private List<CartLine> goods = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = goods.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

            if (line == null)
            {
                goods.Add(new CartLine {Product = product, Quantity = quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Product product)
        {
            goods.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }
        public decimal ComputeTotalValue()
        {
            return goods.Sum(e => e.Product.Price * e.Quantity);
        }
        public void Clear()
        {
            goods.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return goods; }
        }
    }
    
}
