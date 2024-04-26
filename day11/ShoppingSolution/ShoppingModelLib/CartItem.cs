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
        public double? Price;
        public double DiscountPrice;
        public double TotalPrice;
        public double PayOnly;
        double discount;
        public double Discount
        {
            get
            {
                return discount;
            }
            set
            {
                discount = value;
                TotalPrice = Product.Price * Quantity;
                DiscountPrice = Product.Price * discount / 100;
                PayOnly = TotalPrice - DiscountPrice*Quantity;
            }
        }
        public DateTime PriceExpiryDate { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Product Id: {Product.Id}");
            sb.AppendLine($"Product Name: {Product.Name}");
            sb.AppendLine($"Product Price: {Product.Price}");
            sb.AppendLine($"Product Quantity: {Quantity}");
            sb.AppendLine($"Product Total Price: {TotalPrice}");
            sb.AppendLine($"Product Discount Rate : {Discount} %");
            sb.AppendLine($"Product Discount Price: {DiscountPrice}");
            sb.AppendLine($"Pay Only: {PayOnly}");
            sb.AppendLine($"Saved Amount: {TotalPrice - PayOnly}");
            sb.AppendLine($"Product Price Expiry Date: {PriceExpiryDate}");
            return sb.ToString();
        }

    }
}
