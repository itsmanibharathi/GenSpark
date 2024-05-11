using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    internal class EmployeeSolutionFeedbackRepository : EmployeeRepository
    {
        public EmployeeSolutionFeedbackRepository(RequestTrackerContext context) : base(context){ }
        public async Task<IList<SolutionFeedback>> GetAll(int empId)
        {
            throw new NotImplementedException();
        }
    }
}
