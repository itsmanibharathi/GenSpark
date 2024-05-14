namespace ClinicAPI.Interfaces
{
    public interface IRepository <K,T> where T : class
    {
        public Task<T> Add(T entity);
        public Task<T> Get(K key);
        public Task<IEnumerable<T>> Get();
        public Task<T> Update(T entity);
        public Task<bool> Delete(K key);
    }
}
