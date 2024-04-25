using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib
{
    public class CartItem
    {
        public int CartId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public DateTime PriceExpiryDate { get; set; }

        public override string ToString()
        {
            return $"CartId: {CartId}, ProductId: {Product.Id},ProductName: {Product.Name}, Quantity: {Quantity}, Price: {Price}, Discount: {Discount}, PriceExpiryDate: {PriceExpiryDate}";
        }
    }

}
