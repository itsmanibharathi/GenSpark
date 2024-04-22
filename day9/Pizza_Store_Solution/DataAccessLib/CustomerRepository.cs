using Model;
namespace DataAccessLib
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        readonly Dictionary<int, Customer> _repository;
        public CustomerRepository()
        {
            _repository = new Dictionary<int, Customer>();
        }
        int GenerateId()
        {
            if (_repository.Count == 0)
                return 101;
            int id = _repository.Keys.Max();
            return ++id;
        }
        public Customer Add(Customer item)
        {
            if (_repository.ContainsValue(item))
            {
                throw new DuplicateCustomerDetailsException();
            }
            item.Id = GenerateId();
            _repository.Add(item.Id, item);
            return item;
        }
        public Customer Get(int id)
        {
            return _repository[id] ?? throw new CustomerNotFoundException();
        }

        public List<Customer> GetAll()
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository.Values.ToList();
        }

        public Customer Update(Customer item)
        {
            if (_repository.ContainsKey(item.Id))
            {
                _repository[item.Id] = item;
                return item;
            }
            throw new CustomerNotFoundException();
        }
        public Customer Delete(int key)
        {
            if (_repository.ContainsKey(key))
            {
                var Customer = _repository[key];
                _repository.Remove(key);
                return Customer;
            }
            throw new CustomerNotFoundException();
        }

    }
}
