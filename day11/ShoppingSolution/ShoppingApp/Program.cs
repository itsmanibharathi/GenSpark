using ShoppingDALLib;
using ShoppingModelLib;

namespace ShoppingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CartRepository cartRepository = new CartRepository();

            Customer c1 = new Customer { Id = 1, Name = "John" };
            Product p1 = new Product { Id = 1, Name = "Apple", Price = 10 };
            Product p2 = new Product { Id = 2, Name = "Banana", Price = 20 };
            Product p3 = new Product { Id = 3, Name = "Orange", Price = 30 };
            int id = 1;

            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem { CartId = id,  Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
            Console.WriteLine(cartRepository.Add(new Cart { Id = id, CustomerId = c1.Id, Customer = c1, CartItems = cartItems }));
        }
    }
}
