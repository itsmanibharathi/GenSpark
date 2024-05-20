using PizzaHutAPI.Exceptions;
using PizzaHutAPI.Interfaces;
using PizzaHutAPI.Models;

namespace PizzaHutAPI.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _repository;

        public PizzaService(IRepository<int, Pizza> repository)
        {
            _repository = repository;
        }

        public async Task<Pizza> Add(Pizza pizza)
        {
            return await _repository.Add(pizza);
        }

        public async Task<Pizza> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            return await _repository.Get();
        }

        public async Task<IEnumerable<Pizza>> GetMenuItems()
        {
            return (await _repository.Get()).Where(p => p.status == PizzaStatus.Available || p.status == PizzaStatus.Pepareing);
        }

        public async Task<Pizza> MackeAvalable(int id)
        {
            var pizza = await _repository.Get(id);
            pizza.status = PizzaStatus.Available;
            return await _repository.Update(pizza);
        }

        public async Task<Pizza> MakeUnAvalable(int id)
        {
            var pizza = await _repository.Get(id);
            if (pizza.status == PizzaStatus.Available)
            {
                pizza.status = PizzaStatus.UnAvailable;
                return await _repository.Update(pizza);
            }
            else
            {
                throw new AlreadyUpToDateException(id);
            }
        }
        public async Task<Pizza> UpdatePizzaQty(int id, int count)
        {
            var pizza = await _repository.Get(id);
            pizza.QtyInHand += count;
            return await _repository.Update(pizza);
        }
    }
}
