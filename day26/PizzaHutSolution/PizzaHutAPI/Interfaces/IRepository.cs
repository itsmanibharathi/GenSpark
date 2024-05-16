namespace PizzaHutAPI.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        public Task<T> Add(T item);
        public Task<T> Get(K key);
        public Task<IEnumerable<T>> Get();
        public Task<T> Update(T item);
        public Task<bool> Delete(K key);
    }
}
