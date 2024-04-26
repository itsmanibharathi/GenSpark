using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
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

            cartService.Add(1);
        }
        [Test]
        public void CreateCartTest()
        {
            var cart = cartService.Add(2);
            Assert.AreEqual(102, cart.Id);
        }

        [Test]
        public void CreateCartFailTest()
        {
            Assert.Throws<NoCustomerWithGiveIdException>(() => cartService.Add(3));
        }

        [Test]

        public void CreateCartFailTest2()
        {
            Assert.Throws<EmptyDataBaseException>(() => new CartService(new CartRepository(),new ProductRepository() , new CustomerRepository()).Add(3));
        }

        [Test]
        public void AddCartItemTest()
        {
            var cart = cartService.Add(2);
            var cartItem = cartService.AddCartItem(cart.Id, 1, 3);

        }

        [Test]
        public void AddCartItemFailTest()
        {
            var cart = cartService.Add(2);
            Assert.Throws<NoCartWithGiveIdException>(() => cartService.AddCartItem(1,1, 3));
        }

        [Test]
        public void AddCartItemFailTest2()
        {
            var cart = cartService.Add(2);
            Assert.Throws<NoProductWithGiveIdException>(() => cartService.AddCartItem(cart.Id, 3, 3));
        }

        [Test]
        public void AddCartItemFailTest3()
        {
            var cart = cartService.Add(2);
            Assert.Throws<EmptyDataBaseException>(() => new CartService(new CartRepository(), new ProductRepository(), new CustomerRepository()).AddCartItem(cart.Id, 1, 3));
        }

        [Test]
        public void UpdateCartItemTest()
        {
            var cart = cartService.Add(2);
            cartService.AddCartItem(cart.Id, 1, 3);
            var cartItem = cartService.UpdateCartItem(cart.Id, 1, 5);
            Assert.AreEqual(1, cartItem.Product.Id);
            Assert.AreEqual(5, cartItem.Quantity);
            Assert.AreEqual(250000, cartItem.Price);
        }

        [Test]
        public void UpdateCartItemFailTest()
        {
            var cart = cartService.Add(2);
            cartService.AddCartItem(cart.Id, 1, 3);
            Assert.Throws<NoProductWithGiveIdException>(() => cartService.UpdateCartItem(cart.Id, 3, 5));
        }


        [Test]
        public void DeleteCartItemTest()
        {
            var cart = cartService.Add(2);
            cartService.AddCartItem(cart.Id, 1, 3);
            var cartItem = cartService.DeleteCartItem(cart.Id, 1);
            Assert.AreEqual(0, cart.CartItems.Count);
        }
        [Test]
        public void DeleteCartItemFailTest()
        {
            var cart = cartService.Add(2);
            cartService.AddCartItem(cart.Id, 1, 3);
            Assert.Throws<NoProductWithGiveIdException>(() => cartService.DeleteCartItem(cart.Id, 3));
        }

        [Test]
        public void GetCartTest()
        {
            var cart = cartService.Get(101);
            Assert.AreEqual(101, cart.Id);
        }
        [Test]
        public void GetCartFailTest()
        {
            Assert.Throws<NoCartWithGiveIdException>(() => cartService.Get(102));
        }

    }


}
