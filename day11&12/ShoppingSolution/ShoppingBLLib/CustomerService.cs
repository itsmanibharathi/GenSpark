using ShoppingDALLib;
using ShoppingModelLib;
using ShoppingModelLib.Exceptions;
namespace ShoppingBLLib
{
    public class CustomerService
    { 
        readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _repository = customerRepository;
        }

        public Customer Get(int id)
        {
            return _repository.GetByKey(id);
        }

        public List<Customer> GetAll()
        {
            return (List<Customer>) _repository.GetAll();
        }
        public Customer Add(Customer customer)
        {
            return _repository.Add(customer);
        }

        public Customer Update(Customer customer)
        {
            return _repository.Update(customer);
        }

        public Customer Delete(int id)
        {
            return _repository.Delete(id);
        }
    }
}
