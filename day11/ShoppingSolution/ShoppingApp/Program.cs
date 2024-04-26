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

            cartService.AddCartItem(cart.Id, product.Id , 5);


            Console.WriteLine(cart);

            Console.WriteLine(cartService.UpdateCartItem(cart.Id, product.Id, 2));
        }
    }
}
