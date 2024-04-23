using DataAccessLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    /// <summary>
    /// Order Business Logic
    /// </summary>
    public class OrderBL
    {
        readonly IRepository<int, Order> _repository;
        public OrderBL()
        {
            _repository = new OrderRepository();
        }
        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="_new"></param>
        /// <returns>Order object</returns>
        /// <exception cref="DuplicateOrderDetailsException">Duplicate Order DetailsException</exception>
        public Order AddOrder(Order _new)
        {
            try
            {
                return _repository.Add(_new);
            }
            catch (DuplicateOrderDetailsException)
            {
                throw new DuplicateOrderDetailsException();
            }
        }


        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <returns>List of orders</returns>
        /// <exception cref="EmptyDBException">Empty DB Exception</exception>
        public List<Order> GetAllOrders()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (EmptyDBException)
            {
                throw new EmptyDBException();
            }
        }
        /// <summary>
        /// Get Order by Id
        /// </summary>
        /// <param name="id">order id</param>
        /// <returns></returns>
        /// <exception cref="OrderNotFoundException">Order NotFound Exception</exception>
        public Order GetOrder(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch (OrderNotFoundException)
            {
                throw new OrderNotFoundException();
            }
        }

        /// <summary>
        /// Get list Orders by Customer Id
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>List of Orders </returns>
        /// <exception cref="OrderNotFoundException">Order NotFound Exception</exception>
        public List<Order> GetOrderByCustomerId(int id)
        {
            List<Order> orders = GetAllOrders();
            orders = orders.FindAll(order => order.CustomerId == id);
            if (orders == null)
            {
                throw new OrderNotFoundException();
            }
            return orders;
        }


    }
}
