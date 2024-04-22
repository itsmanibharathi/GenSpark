using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using BusinessLogics;
namespace Pizza_Store_App
{
    internal class OrderController
    {
        private readonly OrderBL _orderBL;
        readonly PizzaBL _pizzaBL;
        readonly CustomerBL _customerBL;
        public OrderController(OrderBL orderBL,PizzaBL pizzaBL, CustomerBL customerBL)
        {
            _orderBL = orderBL;
            _pizzaBL = pizzaBL;
            _customerBL = customerBL;

        }

        public void AddOrder()
        {
            try
            {
                Order order = new Order();
                order.CustomerId = Customer.GetCustomerIdFromConsole();
                _customerBL.GetCustomer(order.CustomerId);
                order.OrderDetails = GetOrderDetailsFromConsole();
                
                _orderBL.AddOrder(order);
                _pizzaBL.UpdatePizzaCountByOrder(order);
            }
            catch (DuplicateOrderDetailsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EmptyDBException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public  List<OrderDetails> GetOrderDetailsFromConsole()
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            while (true)
            {
                OrderDetails od = new OrderDetails();
                od.pizzaId = Pizza.GetPizzaIdFromConsole();
                od.size = Pizza.GetPizzaSizeFromConsole();
                od.quantity = Order.GetQuantityFromConsole();
                if(od.quantity < 1)
                {
                    Console.WriteLine("Quantity should be greater than 0");
                    continue;
                }
                else if(od.quantity > _pizzaBL.GetPizzaCount(od.pizzaId, od.size))
                {
                    Console.WriteLine("Quantity should be less than 10");
                    continue;
                }
                od.price = _pizzaBL.GetPizzaPrice(od.pizzaId, od.size);

                orderDetails.Add(od);
                Console.Write("Do you want to add more items (y/n): ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    break;
                }
            }
            return orderDetails;
        }

        public void GetAllOrders()
        {
            try
            {
                List<Order> orders = _orderBL.GetAllOrders();
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
            catch (EmptyDBException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetOrder()
        {
            try
            {
                int id = Order.GetOrderIdFromConsole();
                Order order = _orderBL.GetOrder(id);
                Console.WriteLine(order);
            }
            catch (OrderNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetOrderByCustomerId()
        {
            try
            {
                int id = Customer.GetCustomerIdFromConsole();
                List<Order> orders = _orderBL.GetOrderByCustomerId(id);
                foreach (var order in orders)
                {
                    Console.WriteLine(order);
                }
            }
            catch (OrderNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (EmptyDBException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
