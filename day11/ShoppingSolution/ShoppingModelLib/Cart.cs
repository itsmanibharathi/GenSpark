using System.Text;

namespace ShoppingModelLib
{
    public class Cart
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public List<CartItem>? CartItems { get; set; }

        public double TotalPrice { get; set; }=0;
        public double TotalDiscount { get; set; } = 0;
        public double TotalPay { get; set; } = 0;


        public override string ToString()
        { 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cart Id: {Id}");
            sb.AppendLine($"Cart Name: {Name}");
            sb.AppendLine($"Customer Id: {CustomerId}");
            sb.AppendLine($"Total Pay: {TotalPay}");
            if (CartItems != null)
            {
                sb.AppendLine("Cart Items: ");
                foreach (var item in CartItems)
                {
                    sb.AppendLine("---------------------------------");
                    sb.AppendLine(item.ToString());
                }
                sb.AppendLine("---------------------------------");
            }
            else
            {
                sb.AppendLine("No Items in Cart");
            }
            sb.AppendLine($"Total Price: {TotalPrice}");
            sb.AppendLine($"Total Discount: {TotalDiscount}");
            sb.AppendLine($"Total Pay: {TotalPay}");
            sb.AppendLine($"Total Saved Amount: {TotalPrice - TotalPay}");
            return sb.ToString();
        }
    }
}
