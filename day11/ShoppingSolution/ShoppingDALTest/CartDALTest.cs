using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
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
            cartItems.Add(new CartItem { CartId = id,  Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
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
            cartItems.Add(new CartItem { CartId = id, Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
            Cart cart = new Cart { Id = id, CustomerId = c1.Id, Customer = c1, CartItems = cartItems };
            var result = cartRepository.Add(cart);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void GetCartTest()
        {
            var result = cartRepository.GetByKey(1);
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetCartTestFail()
        {
            Assert.Throws<NoCartWithGiveIdException>(() => cartRepository.GetByKey(2));
        }

        [Test]
        public void GetCartTestEmptyException()
        {
            cartRepository.Delete(1);
            Assert.Throws<EmptyDataBaseException>(() => cartRepository.GetByKey(1));
        }

        [Test]

        public void GetAllCartsTest()
        {
            var result = cartRepository.GetAll();
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAllCartsTestEmptyException()
        {
            cartRepository.Delete(1);
            Assert.Throws<EmptyDataBaseException>(() => cartRepository.GetAll());
        }

        [Test]
        public void UpdateCartsTest()
        {
            Customer c1 = new Customer { Id = 1, Name = "John" };
            Product p1 = new Product { Id = 1, Name = "Apple", Price = 10 };
            Product p2 = new Product { Id = 2, Name = "Banana", Price = 20 };
            Product p3 = new Product { Id = 3, Name = "Orange", Price = 30 };
            int id = 1;

            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem { CartId = id, Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
            Cart cart = new Cart { Id = id, CustomerId = c1.Id, Customer = c1, CartItems = cartItems };

            var result = cartRepository.Update(cart);
            Assert.AreEqual(cart, result);
        }

        [Test]
        public void UpdateCartsTestFail()
        {
            Customer c1 = new Customer { Id = 1, Name = "John" };
            Product p1 = new Product { Id = 1, Name = "Apple", Price = 10 };
            Product p2 = new Product { Id = 2, Name = "Banana", Price = 20 };
            Product p3 = new Product { Id = 3, Name = "Orange", Price = 30 };
            int id = 2;

            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem { CartId = id, Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
            Cart cart = new Cart { Id = id, CustomerId = c1.Id, Customer = c1, CartItems = cartItems };

            Assert.Throws<NoCartWithGiveIdException>(() => cartRepository.Update(cart));
        }

        [Test]
        public void UpdateCartsTestEmptyException()
        {
            Customer c1 = new Customer { Id = 1, Name = "John" };
            Product p1 = new Product { Id = 1, Name = "Apple", Price = 10 };
            Product p2 = new Product { Id = 2, Name = "Banana", Price = 20 };
            Product p3 = new Product { Id = 3, Name = "Orange", Price = 30 };
            int id = 1;

            List<CartItem> cartItems = new List<CartItem>();
            cartItems.Add(new CartItem { CartId = id, Product = p1, Quantity = 2, Price = 10, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p2, Quantity = 3, Price = 20, Discount = 0, PriceExpiryDate = DateTime.Now });
            cartItems.Add(new CartItem { CartId = id, Product = p3, Quantity = 4, Price = 30, Discount = 0, PriceExpiryDate = DateTime.Now });
            Cart cart = new Cart { Id = id, CustomerId = c1.Id, Customer = c1, CartItems = cartItems };

            cartRepository.Delete(1);
            Assert.Throws<EmptyDataBaseException>(() => cartRepository.Update(cart));
        }

        [Test]
        public void DeleteCartTest()
        {
            var result = cartRepository.Delete(1);
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void DeleteCartTestFail()
        {
            Assert.Throws<NoCartWithGiveIdException>(() => cartRepository.Delete(2));
        }

        [Test]
        public void DeleteCartTestEmptyException()
        {
            cartRepository.Delete(1);
            Assert.Throws<EmptyDataBaseException>(() => cartRepository.Delete(1));
        }
    }
}
