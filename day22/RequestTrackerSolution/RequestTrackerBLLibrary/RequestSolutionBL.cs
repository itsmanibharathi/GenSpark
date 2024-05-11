using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class RequestSolutionBL : IRequestSolutionBL
    {
        IRepository<int, RequestSolution> _repository;

        public RequestSolutionBL()
        {
            _repository = new RequestSolutionRepository(new RequestTrackerContext());
        }

        public async Task<RequestSolution> Add(RequestSolution requestSolution)
        {
            return await _repository.Add(requestSolution);
        }

        public async Task<IList<RequestSolution>> Get(int reqId)
        {
            var requestSolutions = await _repository.GetAll();
            return requestSolutions.Where(e => e.RequestId == reqId).ToList();
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IList<RequestSolution>> GetAllByReqId(int reqId)
        {
            var requestSolutions = await _repository.GetAll();
            return requestSolutions.Where(e => e.RequestId== reqId).ToList();
        }
    }
}
