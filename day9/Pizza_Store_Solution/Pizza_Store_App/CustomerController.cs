using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using BusinessLogics;


namespace Pizza_Store_App
{
    internal class CustomerController
    {
        private readonly CustomerBL _customerBL;
        public CustomerController(CustomerBL customerBL)
        {
            _customerBL = customerBL;
        }

        public void AddCustomer()
        {
            try
            {
                Customer _new = _customerBL.AddCustomer();
                Console.WriteLine($"Your Customer Id is: {_new.Id}");
            }
            catch (DuplicateCustomerDetailsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetAllCustomers()
        {
            try
            {
                List<Customer> customers = _customerBL.GetAllCustomers();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer);
                }
            }
            catch (EmptyDBException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetCustomer()
        {
            try
            {
                int id = Customer.GetCustomerIdFromConsole();
                Customer customer = _customerBL.GetCustomer(id);
                Console.WriteLine(customer);
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveCustomer()
        {
            try
            {
                _customerBL.RemoveCustomer();
            }
            catch (CustomerNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }   
    }
}
