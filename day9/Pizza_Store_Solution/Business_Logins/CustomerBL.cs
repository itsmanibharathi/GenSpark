using DataAccessLib;
using Model;

namespace BusinessLogins
{
    public class CustomerBL
    {
        readonly IRepository<int, Customer> _repository;
        public CustomerBL()
        {
            _repository = new CustomerRepository();
        }

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
