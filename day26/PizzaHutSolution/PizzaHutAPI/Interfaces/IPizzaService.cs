using PizzaHutAPI.Models;

namespace PizzaHutAPI.Interfaces
{
    public interface IPizzaService
    {
        public Task<Pizza> Add(Pizza pizza);
        public Task<Pizza> Get(int id);
        public Task<IEnumerable<Pizza>> Get();
        public Task<IEnumerable<Pizza>> GetMenuItems();
        public Task<Pizza> UpdatePizzaQty(int id, int count);
        public Task<Pizza> MackeAvalable(int id);
        public Task<Pizza> MakeUnAvalable(int id);
    }
}
