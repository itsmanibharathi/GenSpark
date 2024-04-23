using Model;
namespace DataAccessLib
{
    /// <summary>
    /// Order repository
    /// </summary>
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
        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="DuplicateOrderDetailsException"></exception>
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
        /// <summary>
        /// Get Order by id
        /// </summary>
        /// <param name="id"> Order Id </param>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>
        /// <exception cref="OrderNotFoundException"></exception>
        public Order Get(int id)
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository[id] ?? throw new OrderNotFoundException();
        }
        /// <summary>
        /// Get all Orders
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>

        public List<Order> GetAll()
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository.Values.ToList();
        }
        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="item">Order Object</param>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>
        /// <exception cref="OrderNotFoundException"></exception>

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

        /// <summary>
        /// Delete Order
        /// </summary>
        /// <param name="key">Order id</param>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>
        /// <exception cref="OrderNotFoundException"></exception>
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
