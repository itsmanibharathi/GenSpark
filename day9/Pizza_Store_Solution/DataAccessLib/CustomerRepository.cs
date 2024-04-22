using Model;
namespace DataAccessLib
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        readonly Dictionary<int, Pizza> _repository;
        public PizzaRepository()
        {
            _repository = new Dictionary<int, Pizza>();
        }
        int GenerateId()
        {
            if (_repository.Count == 0)
                return 101;
            int id = _repository.Keys.Max();
            return ++id;
        }
        public Pizza Add(Pizza item)
        {
            if (_repository.ContainsValue(item))
            {
                throw new DuplicatePizzaDetailsException();
            }
            item.Id = GenerateId();
            _repository.Add(item.Id, item);
            return item;
        }
        public Pizza Get(int id)
        {
            return _repository[id] ?? throw new PizzaNotFoundException();
        }

        public List<Pizza> GetAll()
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository.Values.ToList();
        }

        public Pizza Update(Pizza item)
        {
            if (_repository.ContainsKey(item.Id))
            {
                _repository[item.Id] = item;
                return item;
            }
            throw new PizzaNotFoundException();
        }
        public Pizza Delete(int key)
        {
            if (_repository.ContainsKey(key))
            {
                var Pizza = _repository[key];
                _repository.Remove(key);
                return Pizza;
            }
            throw new PizzaNotFoundException();
        }

    }
}
