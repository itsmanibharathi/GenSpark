using DataAccessLib;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogins
{
    public class PizzaBL
    {
        readonly IRepository<int, Pizza> _repository;
        public PizzaBL()
        {
            _repository = new PizzaRepository();
        }

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
        public Pizza GetPizza()
        {
            try
            {
                int id = Pizza.GetPizzaIdFromConsole();
                return _repository.Get(id);
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }
        public Pizza RemovePizza()
        {
            try
            {
                int id = Pizza.GetPizzaIdFromConsole();
                return _repository.Delete(id);
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }

        public Pizza UpdatePizza()
        {
            try
            {
                Pizza Pizza = new Pizza();
                Pizza.BuildPizzaFromConsole();
                return _repository.Update(Pizza);
            }
            catch (PizzaNotFoundException)
            {
                throw new PizzaNotFoundException();
            }
        }
    }
}
