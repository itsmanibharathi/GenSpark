﻿using DataAccessLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    public class OrderBL
    {
        readonly IRepository<int, Order> _repository;
        public OrderBL()
        {
            _repository = new OrderRepository();
        }

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
