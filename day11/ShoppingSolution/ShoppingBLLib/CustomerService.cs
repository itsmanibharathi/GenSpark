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

        public void Add(Customer customer)
        {
            _repository.Add(customer);
        }

        public void Update(Customer customer)
        {
            _repository.Update(customer);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
