﻿using Model;
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
                return 1;
            int id = _repository.Keys.Max();
            return ++id;
        }
        /// <summary>
        /// Add Pizza
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="DuplicatePizzaDetailsException"></exception>
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
        /// <summary>
        /// Get Pizza by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>
        /// <exception cref="PizzaNotFoundException"></exception>
        public Pizza Get(int id)
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository[id] ?? throw new PizzaNotFoundException();
        }
        /// <summary>
        /// Get all Pizzas
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>
        public List<Pizza> GetAll()
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            return _repository.Values.ToList();
        }
        /// <summary>
        /// Update Pizza by id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>
        /// <exception cref="PizzaNotFoundException"></exception>
        public Pizza Update(Pizza item)
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
            if (_repository.ContainsKey(item.Id))
            {
                _repository[item.Id] = item;
                return item;
            }
            throw new PizzaNotFoundException();
        }
        /// <summary>
        /// Delete Pizza by id
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="EmptyDBException"></exception>
        /// <exception cref="PizzaNotFoundException"></exception>
        public Pizza Delete(int key)
        {
            if (_repository.Count == 0)
                throw new EmptyDBException();
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
