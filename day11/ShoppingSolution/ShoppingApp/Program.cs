using ShoppingBLLib;
using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;

namespace ShoppingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                var customerRepository = new CustomerRepository();
                var customerService = new CustomerService(customerRepository);
                var customer = customerService.Get(1);
                System.Console.WriteLine(customer.Name);

            }
            catch (EmptyDataBaseException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
