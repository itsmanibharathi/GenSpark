using ShoppingModelLib;

namespace ShoppingDALLib
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        readonly Dictionary<int, Customer> _customers;

        public CustomerRepository()
        {
            _customers = new Dictionary<int, Customer>();
        }

        int GenrateKey()
        {
            if (_customers.Count == 0)
            {
                return 100;
            }
            return _customers.Keys.Max() + 1;
        }   
        public Customer Add(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
