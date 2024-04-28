using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;

namespace ShoppingApp
{
    internal class Program
    {
        static async Task Main(string[] args)
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
            await customerService.Add(customer);

            Product product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 50000
            };

            await productService.Add(product);

            int carID = await cartService.Add(1);

            Cart cart = await cartService.Get(carID);


            await cartService.AddCartItem(cart.Id, product.Id, 5);


            Console.WriteLine(cart);

            //Console.WriteLine(cartService.UpdateCartItem(cart.Id, product.Id, 2));
        }
    }
}
