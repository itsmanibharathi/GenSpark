using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogics;
using Model;

namespace Pizza_Store_App
{
    /// <summary>
    /// Pizza Controller
    /// </summary>
    public class PizzaController
    {
        PizzaBL _pizzaBL;
        public PizzaController(PizzaBL pizzaBL)
        {
            _pizzaBL = pizzaBL;
        }
        /// <summary>
        /// Add new Pizza
        /// </summary>
        public void AddPizza()
        {
            try
            {
                _pizzaBL.AddPizza();
            }
            catch (DuplicatePizzaDetailsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Get all Pizzas
        /// </summary>
        public void GetAllPizzas()
        {
            try
            {
                List<Pizza> pizzas = _pizzaBL.GetAllPizzas();
                foreach (var pizza in pizzas)
                {
                    Console.WriteLine(pizza);
                }
            }
            catch (EmptyDBException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Get Pizza by ID
        /// </summary>
        public void GetPizza()
        {
            try
            {
                int id = Pizza.GetPizzaIdFromConsole();
                Pizza pizza = _pizzaBL.GetPizza(id);
                Console.WriteLine(pizza);
            }
            catch (PizzaNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Remove Pizza from DB
        /// </summary>
        public void RemovePizza()
        {
            try
            {
                int id = Pizza.GetPizzaIdFromConsole();
                Pizza pizza = _pizzaBL.RemovePizza(id);
                Console.WriteLine(pizza);
            }
            catch (PizzaNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Update Pizza Count
        /// </summary>
        public void UpdatePizza()
        {
            try
            {
                int id = Pizza.GetPizzaIdFromConsole();
                Pizza pizza = _pizzaBL.UpdatePizza(id);
                Console.WriteLine(pizza);
            }
            catch (PizzaNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
    }
}
