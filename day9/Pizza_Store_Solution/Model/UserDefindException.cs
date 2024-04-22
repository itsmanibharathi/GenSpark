using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmptyDBException : Exception
    {
        string msg;
        public EmptyDBException()
        {
            msg = "Database is empty";
        }
        public override string Message => msg;
    }
    public class DuplicatePizzaDetailsException : Exception
    {
        string msg;
        public DuplicatePizzaDetailsException()
        {
            msg = "Pizza name already exists";
        }
        public override string Message => msg;
    }
    public class PizzaNotFoundException : Exception
    {
        string msg;
        public PizzaNotFoundException()
        {
            msg = "Pizza not found";
        }
        public override string Message => msg;
    }
    public class DuplicateOrderDetailsException : Exception
    {
        string msg;
        public DuplicateOrderDetailsException()
        {
            msg = "Orders already exists ";
        }
        public override string Message => msg;
    }
    public class OrderNotFoundException : Exception
    {
        string msg;
        public OrderNotFoundException()
        {
            msg = "Order not found";
        }
        public override string Message => msg;
    }

    public class DuplicateCustomerDetailsException : Exception
    {
        string msg;
        public DuplicateCustomerDetailsException()
        {
            msg = "Customer Details already exists";
        }
        public override string Message => msg;
    }
    public class CustomerNotFoundException : Exception
    {
        string msg;
        public CustomerNotFoundException()
        {
            msg = "Customer not found";
        }
        public override string Message => msg;
    }
}
