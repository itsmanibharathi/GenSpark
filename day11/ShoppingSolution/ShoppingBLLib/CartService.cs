using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public CartItem UpdateCartItem(int cartId, int productId, int quantity)
        {
            try
            {
                var cart = _cartRepository.GetByKey(cartId);
                // product is not found in the cart
                if (cart.CartItems.Find(x => x.Product.Id == productId) == null)
                {
                    throw new NoProductWithGiveIdException();
                }
               
                foreach (var item in cart.CartItems)
                {
                    if (item.Product.Id == productId)
                    {
                        item.Quantity = quantity;
                        item.Price = item.Product.Price * quantity;
                    }
                }
                _cartRepository.Update(cart);
                return cart.CartItems.Find(x => x.Product.Id == productId);
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
                    Quantity = quantity,
                    Price = product.Price * quantity
                };
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

        public Cart Get(int id)
        {
            return _cartRepository.GetByKey(id);
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

        public void Delete(int id)
        {
            _cartRepository.Delete(id);
        }
    }
}
