using API.Context;
using API.Exceptions;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorys
{
    public class ProductRepository : IRepository<int, Product>
    {
        private readonly DBEkartContext _context;

        public ProductRepository(DBEkartContext context)
        {
            _context = context;
        }
        public async Task<Product> Add(Product item)
        {
            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch(Exception)
            {
                throw new UnableToDoneActionException("Unable to add product");

            }
        }

        public Task<bool> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> Get()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw new UnableToDoneActionException("Unable to get products");
            }
        }

        public Task<Product> Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
