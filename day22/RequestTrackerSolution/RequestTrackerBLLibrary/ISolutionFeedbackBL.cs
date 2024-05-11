using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionFeedbackBL
    {
        public Task<SolutionFeedback> Add(SolutionFeedback feedback);
        public Task<IList<SolutionFeedback>> GetAllByEmpId(int empId);
        public Task<IList<SolutionFeedback>> GetAll();

    }
}
