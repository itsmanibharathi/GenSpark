using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;
using RequestTrackerModelLibrary.Exceptions;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository 
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

        public virtual async Task<IList<SolutionFeedback>> Get(int empId)
        {
            var feedbacks = _context.Feedbacks
                    .Where(f => f.Solution.SolvedBy == empId && f.Solution.SolvedBy != f.FeedbackBy) 
                    .ToList();
            if (feedbacks == null)
            {
                throw new EmployeeIdNotFoundException(empId);
            }
            return feedbacks;
        }

        public virtual async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync() ?? throw new DatabaseEmptyException("Feedback");
        }
    }
}
