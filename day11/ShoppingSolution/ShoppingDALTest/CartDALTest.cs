using ShoppingDALLib;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class CartDALTest
    {
        IRepository<int, Cart> cartRepository;
        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();

            Customer c1 = new Customer { Id = 1, Name = "John" };
            Product p1 = new Product { Id = 1, Name = "Apple", Price = 10 };
            Product p2 = new Product { Id = 2, Name = "Banana", Price = 20 };
            Product p3 = new Product { Id = 3, Name = "Orange", Price = 30 };
            int id = 1;

            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem { CartId = id, ProductId = p1.Id, Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, ProductId = p2.Id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, ProductId = p3.Id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartRepository.Add(new Cart { Id = id,CustomerId = c1.Id,Customer = c1 , CartItems = cartItems});
        }

        [Test]
        public void AddCartTest()
        {
            Customer c1 = new Customer { Id = 1, Name = "John" };
            Product p1 = new Product { Id = 1, Name = "Apple", Price = 10 };
            Product p2 = new Product { Id = 2, Name = "Banana", Price = 20 };
            Product p3 = new Product { Id = 3, Name = "Orange", Price = 30 };
            int id = 2;

            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem { CartId = id, ProductId = p1.Id, Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, ProductId = p2.Id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, ProductId = p3.Id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
            Cart cart = new Cart { Id = id, CustomerId = c1.Id, Customer = c1, CartItems = cartItems };
            var result = cartRepository.Add(cart);
            Assert.AreEqual(cart, result);
        }
    }
}
