using DataAccessLib;
using Model;

namespace BusinessLogics
{
    /// <summary>
    /// Customer Business Logic
    /// </summary>
    public class CustomerBL
    {
        readonly IRepository<int, Customer> _repository;
        public CustomerBL()
        {
            _repository = new CustomerRepository();
        }
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <returns>Object</returns>
        /// <exception cref="DuplicateCustomerDetailsException">Duplicate Customer Details Exception</exception>
        public Customer AddCustomer()
        {
            try
            {
                Customer Customer = new Customer();
                Customer.BuildCustomerFromConsole();
                return _repository.Add(Customer);
            }
            catch (DuplicateCustomerDetailsException)
            {
                throw new DuplicateCustomerDetailsException();
            }
        }
        /// <summary>
        /// Get All Customers
        /// </summary>
        /// <returns>Return list of customer</returns>
        /// <exception cref="EmptyDBException"></exception>
        public List<Customer> GetAllCustomers()
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
        /// Get Customer by Id
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns></returns>
        /// <exception cref="CustomerNotFoundException">Customer NotFound Exception</exception>
        public Customer GetCustomer(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch (CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }

        }
        /// <summary>
        /// Remove Customer 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomerNotFoundException">Customer NotFound Exception</exception>
        public Customer RemoveCustomer()
        {
            try
            {
                int id = Customer.GetCustomerIdFromConsole();
                return _repository.Delete(id);
            }
            catch (CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }
        }
        /// <summary>
        /// Update Customer
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomerNotFoundException">Customer NotFound Exception</exception>
        public Customer UpdateCustomer()
        {
            try
            {
                Customer Customer = new Customer();
                Customer.BuildCustomerFromConsole();
                return _repository.Update(Customer);
            }
            catch (CustomerNotFoundException)
            {
                throw new CustomerNotFoundException();
            }
        }
    }
}
