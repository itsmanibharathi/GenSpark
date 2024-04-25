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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cart Id: {Id}");
            if(Name != null)
            {
                sb.AppendLine($"Cart Name: {Name}");
            }
            if(Customer != null) {
                sb.AppendLine($"Customer Id: {Customer.Id}");
                sb.AppendLine($"Customer Name: {Customer.Name}");
            }
            if(CartItems != null)
            {
                sb.AppendLine("Cart Items:");
                sb.AppendLine($"Cart Items Count: {CartItems.Count}");
                foreach (var item in CartItems)
                {
                    sb.AppendLine("================================================");
                    sb.AppendLine(item.ToString());
                }
            }
            else
            {
                sb.AppendLine("Cart Items: None");
            }

            return sb.ToString();
        }
    }
}
