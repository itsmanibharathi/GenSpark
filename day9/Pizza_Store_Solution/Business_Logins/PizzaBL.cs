﻿using DataAccessLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics
{
    /// <summary>
    /// Pizza Business Logic
    /// </summary>
    public class PizzaBL
    {
        readonly IRepository<int, Pizza> _repository;
        public PizzaBL()
        {
            _repository = new PizzaRepository();
        }
        /// <summary>
        /// Add Pizza
        /// </summary>
        /// <returns>New Pizza opject</returns>
        /// <exception cref="DuplicatePizzaDetailsException"></exception>
        public Pizza AddPizza()
        {
            try
            {
                Pizza Pizza = new Pizza();
                Pizza.BuildPizzaFromConsole();
                return _repository.Add(Pizza);
            }
            catch (DuplicatePizzaDetailsException)
            {
                throw new DuplicatePizzaDetailsException();
            }
        }
        /// <summary>
        /// Get All Pizzas
        /// </summary>
        /// <returns> List of Pizzas </returns>
        /// <exception cref="EmptyDBException">Empty DB Exception</exception>

        public List<Pizza> GetAllPizzas()
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
        /// <summary>
        /// Get Pizza by Id
        /// </summary>
        /// <param name="id">Pizza id</param>
        /// <returns></returns>
        /// <exception cref="PizzaNotFoundException">Pizza NotFound Exception</exception>
        public Pizza GetPizza(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }
        /// <summary>
        /// Remove Pizza from DB
        /// </summary>
        /// <param name="id">Pizza Id</param>
        /// <returns></returns>
        /// <exception cref="PizzaNotFoundException"></exception>
        public Pizza RemovePizza(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }

        public Pizza UpdatePizza(int id)
        {
            try
            {
                Pizza Pizza = GetPizza(id);
                Pizza.UpdatePizzaCountFromConsole();
                return _repository.Update(Pizza);
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }
        public void PrintPizzaMenu()
        {
            try
            {
                foreach (var item in _repository.GetAll())
                {
                    Console.WriteLine("Pizza Menu:");
                    Console.WriteLine(item);

                }
            }
            catch (EmptyDBException)
            {
                throw new EmptyDBException();
            }
        }

        public double GetPizzaPrice(int id,char size)
        {
            try
            {
                Pizza pizza = _repository.Get(id);
                if (pizza.Pizza_info.ContainsKey(size))
                {
                    return pizza.Pizza_info[size].Price;
                }
                else
                {
                    throw new PizzaNotFoundException();
                }
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }
        public int GetPizzaCount(int id, char size)
        {
            try
            {
                Pizza pizza = _repository.Get(id);
                if (pizza.Pizza_info.ContainsKey(size))
                {
                    return pizza.Pizza_info[size].Count;
                }
                else
                {
                    throw new PizzaNotFoundException();
                }
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }

        public void UpdatePizzaCountByOrder(Order order) 
        {             
            foreach (var orderDetails in order.OrderDetails)
            {
                Pizza pizza = _repository.Get(orderDetails.pizzaId);
                pizza.UpdatePizzaCount(orderDetails.size, pizza.Pizza_info[orderDetails.size].Count - orderDetails.quantity);
                _repository.Update(pizza);
            }
        }

    }
}
