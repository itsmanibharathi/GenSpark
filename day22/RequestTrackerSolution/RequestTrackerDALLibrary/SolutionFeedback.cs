using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;

        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<SolutionFeedback> Get(int key)
        {
            var SolutionFeedback = _context.Feedbacks.SingleOrDefault(e => e.FeedbackId == key);
            return SolutionFeedback;
        }

        public virtual async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var SolutionFeedback = await Get(entity.FeedbackId);
            if (SolutionFeedback != null)
            {
                _context.Entry<SolutionFeedback>(SolutionFeedback).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return await Get(entity.SolutionId);
        }
        public async Task<bool> Delete(int key)
        {
            var SolutionFeedback = await Get(key);
            if (SolutionFeedback != null)
            {
                _context.Feedbacks.Remove(SolutionFeedback);
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
