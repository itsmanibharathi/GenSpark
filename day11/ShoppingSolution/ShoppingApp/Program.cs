using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;

namespace ShoppingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository customerRepository = new CustomerRepository();
            CustomerService customerService = new CustomerService(customerRepository);
            ProductRepository productRepository = new ProductRepository();
            ProductService productService = new ProductService(productRepository);
            CartRepository cartRepository = new CartRepository();
            CartService cartService = new CartService(cartRepository, productRepository, customerRepository);

            Customer customer = new Customer
            {
                Id = 1,
                Name = "John Doe",
                Phone = "1234567890",
                Age = 25
            };
            customerService.Add(customer);

            Product product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 50000
            };

            productService.Add(product);

            Cart cart = cartService.Add(1);
            
            CartItem cartItem = new CartItem
            {
                Product = product,
                Quantity = 2,
                Price = product.Price * 2
            };
            cart.CartItems.Add(cartItem);

            Console.WriteLine(cart);
        }
    }
}
