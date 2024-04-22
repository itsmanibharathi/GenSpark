using DataAccessLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogins
{
    public class OrderBL
    {
        readonly IRepository<int, Order> _repository;
        public OrderBL()
        {
            _repository = new OrderRepository();
        }

        public Order AddOrder()
        {
            try
            {
                Order Order = new Order();
                //Order.BuildOrderFromConsole();
                return _repository.Add(Order);
            }
            catch (DuplicateOrderDetailsException)
            {
                throw new DuplicateOrderDetailsException();
            }
        }

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
        public Order GetOrder()
        {
            try
            {
                int id = Order.GetOrderIdFromConsole();
                return _repository.Get(id);
            }
            catch (OrderNotFoundException)
            {
                throw new OrderNotFoundException();
            }
        }
        public Order RemoveOrder()
        {
            try
            {
                int id = Order.GetOrderIdFromConsole();
                return _repository.Delete(id);
            }
            catch (OrderNotFoundException)
            {
                throw new OrderNotFoundException();
            }
        }

        public Order UpdateOrder()
        {
            try
            {
                Order Order = new Order();
                //Order.BuildOrderFromConsole();
                return _repository.Update(Order);
            }
            catch (OrderNotFoundException)
            {
                throw new OrderNotFoundException();
            }
        }
    }
}
