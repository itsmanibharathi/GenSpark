using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTets
{
    internal class CartBLTest
    {
        CartService cartService;
        CartRepository cartRepository;
        ProductService productService;
        ProductRepository productRepository;
        CustomerService customerService;
        CustomerRepository customerRepository;

        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
            productRepository = new ProductRepository();
            customerRepository = new CustomerRepository();
            productService = new ProductService(productRepository);
            customerService = new CustomerService(customerRepository);
            cartService = new CartService(cartRepository, productRepository, customerRepository);
            customerService.Add(new Customer { Id = 1, Name = "Mani" });
            customerService.Add(new Customer { Id = 2, Name = "Kiko" });
            productService.Add(new Product { Id = 1, Name = "Laptop", Price = 50000 });
            productService.Add(new Product { Id = 2, Name = "Mobile", Price = 20000 });
            var cart = cartService.Add(1);
            cartService.AddCartItem(cart.Id, 1, 3);

        }
        [Test]
        public void CreateCartTest()
        {
            var cart = cartService.Add(2);
            Assert.AreEqual(102, cart.Id);
        }
    }
}
