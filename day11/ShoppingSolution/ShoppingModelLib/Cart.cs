using System.Text;

namespace ShoppingModelLib
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<CartItem> CartItems { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cart Id: {Id}");
            sb.AppendLine($"Customer Id: {CustomerId}");
            sb.AppendLine($"Customer Name: {Customer.Name}");
            sb.AppendLine("Cart Items:");
            foreach (var item in CartItems)
            {
                sb.AppendLine("==================================================");
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
