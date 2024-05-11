using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeRequestBL : IEmployeeRequestBL
    {
        private readonly IRepository<int, Request> _repository;

        public EmployeeRequestBL( )
        {
            _repository = new RequestRepository(new RequestTrackerContext());
        }

        public async Task<Request> Add(Request requst)
        {
           return await _repository.Add(requst);
        }
        public async Task<Request> Get(int empID)
        {
            return await _repository.Get(empID);
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IList<Request>> GetAllByEmpId(int empId)
        {
            var requsts = await _repository.GetAll();
            return requsts.Where(e => e.RequestRaisedBy == empId).ToList();
        }

        public async Task<Request> Update(Request request)
        {
            return await _repository.Update(request);
        }

    }
}
