﻿using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ShoppingBLLib
{
    public class CartService
    {
        
        readonly CartRepository _cartRepository;
        readonly ProductRepository _productRepository;
        readonly CustomerRepository _customerRepository;

        public CartService(CartRepository cartRepository, ProductRepository productRepository, CustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }
        public Cart Add(int customerID)
        {
            try
            {
                var customer = _customerRepository.GetByKey(customerID);
                var cart = new Cart 
                {
                    Customer = customer,
                    CartItems = new List<CartItem>()
                };
                return _cartRepository.Add(cart);
            }
            catch (NoCustomerWithGiveIdException)
            {
                throw new NoCustomerWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }

        }
        
        public Cart Get(int id)
        {
            try
            {
                return _cartRepository.GetByKey(id);
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }

        public Cart GetByCustomerId(int customerId)
        {
            try
            {
                var cart = _cartRepository.GetAll().FirstOrDefault(x => x.Customer.Id == customerId);
                if (cart == null)
                {
                    throw new CustomerNotCreateCartException();
                }
                return cart;
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }

        public List<Cart> GetAll()
        {
            try
            {
                return (List<Cart>)_cartRepository.GetAll();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
            
        }

        public Cart Update(int customerId,int cartId)
        {
            try
            {
                var customer = _customerRepository.GetByKey(customerId);
                var cart = _cartRepository.GetByKey(cartId);
                cart.Customer = customer;
                return _cartRepository.Update(cart);
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _cartRepository.Delete(id);
                return true;
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }



        public List<CartItem> AddCartItem(int cartId, int productId, int quantity)
        {
            try
            {
                var cart = _cartRepository.GetByKey(cartId);
                var product = _productRepository.GetByKey(productId);
                var cartItem = new CartItem
                {
                    CartId = cartId,
                    Product = product,
                    Quantity = quantity
                };
                SetDiscount(cartItem);
                Console.WriteLine($"Totla Price: {cartItem.TotalPrice}");
                cart.TotalPrice += cartItem.TotalPrice;
                cart.TotalDiscount += cartItem.DiscountPrice;
                cart.TotalPay += cartItem.PayOnly;
                cart.CartItems.Add(cartItem);
                _cartRepository.Update(cart);
                return cart.CartItems;
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (NoProductWithGiveIdException)
            {
                throw new NoProductWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }

        }
        public CartItem UpdateCartItem(int cartId, int productId, int quantity)
        {
            try
            {
                var cart = _cartRepository.GetByKey(cartId);
                // product is not found in the cart
                if (cart.CartItems.Find(x => x.Product.Id == productId) == null)
                {
                    throw new ProductNotInCartException();
                }

                foreach (var item in cart.CartItems)
                {
                    if (item.Product.Id == productId)
                    {
                        item.Quantity = quantity;
                        item.Price = item.Product.Price * quantity;
                        SetDiscount(item);
                    }
                }
                _cartRepository.Update(cart);
                return cart.CartItems.Find(x => x.Product.Id == productId);
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }


        [ExcludeFromCodeCoverage]
        public void SetDiscount(CartItem cartItem)
        {
            if(cartItem.Quantity >= 15)
            {
                cartItem.Discount = 3;
                cartItem.PriceExpiryDate = DateTime.Now.AddDays(1);
            }
            else if(cartItem.Quantity >= 10)
            {
                cartItem.Discount = 2;
                cartItem.PriceExpiryDate = DateTime.Now.AddDays(2);
            }
            else if(cartItem.Quantity >= 5)
            {
                cartItem.Discount = 1;
                cartItem.PriceExpiryDate = DateTime.Now.AddDays(3);
            }
            else
            {
                cartItem.Discount = 0;
                cartItem.PriceExpiryDate = DateTime.Now.AddDays(10);
            }

        }
        public List<CartItem> DeleteCartItem(int cartId, int productId)
        {
            try
            {
                var cart = _cartRepository.GetByKey(cartId);
                var cartItem = cart.CartItems.Find(x => x.Product.Id == productId);
                if (cartItem == null)
                {
                    throw new NoProductWithGiveIdException();
                }
                cart.CartItems.Remove(cartItem);
                _cartRepository.Update(cart);
                return cart.CartItems;
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (NoProductWithGiveIdException)
            {
                throw new NoProductWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }

        public List<CartItem> GetAllCartItems(int cartId)
        {
            try
            {
                var cart = _cartRepository.GetByKey(cartId);
                return cart.CartItems;
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }

        public List<CartItem> GetAllCartByCustomerId(int customerId)
        {
            try
            {
                var cart = _cartRepository.GetAll().FirstOrDefault(x => x.Customer.Id == customerId);
                if (cart == null)
                {
                    throw new NoCartWithGiveIdException();
                }
                return cart.CartItems;
            }
            catch (NoCartWithGiveIdException)
            {
                throw new NoCartWithGiveIdException();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
        }


    }
}
