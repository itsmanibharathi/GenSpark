using Model;
namespace DataAccessLib
{
    public class OrderRepository : IRepository<int, Order>
    {
        readonly Dictionary<int, Order> _repository;
        public OrderRepository()
        {
            _repository = new Dictionary<int, Order>();
        }
        int GenerateId()
        {
            if (_repository.Count == 0)
                return 1001;
            int id = _repository.Keys.Max();
            return ++id;
        }
        public Order Add(Order item)
        {
            if (_repository.ContainsValue(item))
            {
                throw new DuplicateOrderDetailsException();
            }
            item.Id = GenerateId();
            _repository.Add(item.Id, item);
            return item;
        }
        public Order Get(int id)
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository[id] ?? throw new OrderNotFoundException();
        }

        public List<Order> GetAll()
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository.Values.ToList();
        }

        public Order Update(Order item)
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            if (_repository.ContainsKey(item.Id))
            {
                _repository[item.Id] = item;
                return item;
            }
            throw new OrderNotFoundException();
        }
        public Order Delete(int key)
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            if (_repository.ContainsKey(key))
            {
                var Order = _repository[key];
                _repository.Remove(key);
                return Order;
            }
            throw new OrderNotFoundException();
        }
    }
}
