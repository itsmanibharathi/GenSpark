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

        public async Task<int> Get(int id)
        {
            return (await _repository.GetByKey(id)).Id;
        }
        
        public async Task<Customer> GetCustomer(int id)
        {
            return await _repository.GetByKey(id);
        }

        public async Task<int> Add(Customer customer)
        {
            return (await _repository.Add(customer)).Id;
        }

        public async Task<Customer> Update(Customer customer)
        {
            return await _repository.Update(customer);
        }

        public async Task<Customer> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
