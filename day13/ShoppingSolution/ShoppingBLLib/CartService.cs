using ShoppingDALLib;
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
        public async Task<int> Add(int customerID)
        {
            try
            {
                var customer = await _customerRepository.GetByKey(customerID);
                var cart = new Cart 
                {
                    Customer = customer,
                    CartItems = new List<CartItem>()
                };
                return (await _cartRepository.Add(cart)).Id;
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
        
        public async Task<Cart> Get(int id)
        {
            try
            {
                return await _cartRepository.GetByKey(id);
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

        public async Task<Cart> GetByCustomerId(int customerId)
        {
            try
            {
                var cart = (await _cartRepository.GetAll()).FirstOrDefault(x => x.Customer.Id == customerId);
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

        public async Task<List<Cart>> GetAll()
        {
            try
            {
                return await _cartRepository.GetAll();
            }
            catch (EmptyDataBaseException)
            {
                throw new EmptyDataBaseException();
            }
            
        }

        public async Task<Cart> Update(int customerId,int cartId)
        {
            try
            {
                var customer = await _customerRepository.GetByKey(customerId);
                var cart = await _cartRepository.GetByKey(cartId);
                cart.Customer = customer;
                return await _cartRepository.Update(cart);
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _cartRepository.Delete(id)==null ? false : true;
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



        public async Task<List<CartItem>> AddCartItem(int cartId, int productId, int quantity)
        {
            try
            {
                var cart = _cartRepository.GetByKey(cartId);
                var product = _productRepository.GetByKey(productId);
                var cartItem = new CartItem
                {
                    CartId = cartId,
                    Product = product.Result,
                    Quantity = quantity
                };
                SetDiscount(cartItem);
                Console.WriteLine($"Totla Price: {cartItem.TotalPrice}");
                cart.Result.TotalPrice += cartItem.TotalPrice;
                cart.Result.TotalDiscount += cartItem.DiscountPrice;
                cart.Result.TotalPay += cartItem.PayOnly;
                cart.Result.CartItems.Add(cartItem);
                return _cartRepository.Update(cart.Result).Result.CartItems;
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
        public async Task<CartItem> UpdateCartItem(int cartId, int productId, int quantity)
        {
            try
            {
                var cart = await _cartRepository.GetByKey(cartId);
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
                return _cartRepository.Update(cart).Result.CartItems.Find(x => x.Product.Id == productId);
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
        public async Task<List<CartItem>> DeleteCartItem(int cartId, int productId)
        {
            try
            {
                var cart = await _cartRepository.GetByKey(cartId);
                var cartItem = cart.CartItems.Find(x => x.Product.Id == productId);
                if (cartItem == null)
                {
                    throw new NoProductWithGiveIdException();
                }
                cart.CartItems.Remove(cartItem);
                return _cartRepository.Update(cart).Result.CartItems;
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

        public async Task<List<CartItem>> GetAllCartItems(int cartId)
        {
            try
            {
                return (await _cartRepository.GetByKey(cartId)).CartItems;
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

        public async Task<List<CartItem>> GetAllCartByCustomerId(int customerId)
        {
            try
            {
                var cart = (await _cartRepository.GetAll()).FirstOrDefault(x => x.Customer.Id == customerId);
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
