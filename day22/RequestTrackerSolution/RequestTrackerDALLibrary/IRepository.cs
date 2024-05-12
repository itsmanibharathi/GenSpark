using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    /// <summary>
    /// Represents a generic repository interface for CRUD operations.
    /// </summary>
    /// <typeparam name="K">The type of the key.</typeparam>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IRepository<K, T> where T : class
    {
        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous operation and returns the added entity.</returns>
        public Task<T> Add(T entity);

        /// <summary>
        /// Retrieves an entity from the repository based on the specified key.
        /// </summary>
        /// <param name="key">The key of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation and returns the retrieved entity.</returns>
        public Task<T> Get(K key);

        /// <summary>
        /// Retrieves all entities from the repository.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation and returns a list of all entities.</returns>
        public Task<IList<T>> GetAll();

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task that represents the asynchronous operation and returns the updated entity.</returns>
        public Task<T> Update(T entity);

        /// <summary>
        /// Deletes an entity from the repository based on the specified key.
        /// </summary>
        /// <param name="key">The key of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous operation and returns a boolean indicating whether the deletion was successful.</returns>
        public Task<bool> Delete(K key);
    }
}
