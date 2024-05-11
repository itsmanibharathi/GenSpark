using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeRequestBL
    {
        public Task<Request> Add(Request requst);
        public Task<Request> Get(int empID);

        public Task<IList<Request>> GetAll();   
        public Task<IList<Request>> GetAllByEmpId(int empId);

        public Task<Request> Update(Request request);
    }
}
