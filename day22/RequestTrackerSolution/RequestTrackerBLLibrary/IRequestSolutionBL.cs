using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestSolutionBL
    {
        public Task<RequestSolution> Add(RequestSolution requestSolution);
        public Task<IList<RequestSolution>> Get(int requstId);
        public Task<IList<RequestSolution>> GetAll();
        public Task<IList<RequestSolution>> GetAllByReqId(int empId);

    }
}
