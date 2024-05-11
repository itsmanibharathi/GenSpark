using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionFeedbackBL : ISolutionFeedbackBL
    {
        readonly IRepository<int, SolutionFeedback> repository;

        public SolutionFeedbackBL()
        {
            repository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback feedback)
        {
            return await repository.Add(feedback);
        }
    }
}
