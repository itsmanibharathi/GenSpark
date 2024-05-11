using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>
    {
        protected readonly RequestTrackerContext _context;

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Request> Get(int key)
        {
            var request = await _context.Requests.SingleOrDefaultAsync(e => e.RequestNumber == key);
            return request;
        }

        public virtual async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            var request = await Get(entity.RequestNumber);
            if (request != null)
            {
                _context.Entry<Request>(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return await Get(entity.RequestNumber);
        }
        public async Task<bool> Delete(int key)
        {
            var request = await Get(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
