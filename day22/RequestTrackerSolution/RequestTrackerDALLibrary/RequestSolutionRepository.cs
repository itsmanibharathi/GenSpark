using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Exceptions;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>
    {
        protected readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<RequestSolution> Get(int key)
        {
            var RequestSolution = _context.RequestSolutions.SingleOrDefault(e => e.SolutionId == key);
            if (RequestSolution == null)
            {
                throw new RequestSolutionIdNotFoundException(key);
            }
            return RequestSolution;
        }

        public virtual async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync()?? throw new DatabaseEmptyException("Request Solution");
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            var requestSolution = await Get(entity.SolutionId);
            if (requestSolution != null)
            {
                _context.Entry<RequestSolution>(requestSolution).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return await Get(entity.SolutionId);
        }
        public async Task<bool> Delete(int key)
        {
            var requestSolution = await Get(key);
            if (requestSolution != null)
            {
                _context.RequestSolutions.Remove(requestSolution);
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
