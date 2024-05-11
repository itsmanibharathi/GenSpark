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
        readonly SolutionFeedbackRepository repository;

        public SolutionFeedbackBL()
        {
            repository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }

        public async Task<SolutionFeedback> Add(SolutionFeedback feedback)
        {
            return await repository.Add(feedback);
        }

        public async Task<IList<SolutionFeedback>> GetAllByEmpId(int empId)
        {
            return await repository.Get(empId);
        }

        public async Task<IList<SolutionFeedback>> GetAll()
        {
            return await repository.GetAll();
        }
    }
}
