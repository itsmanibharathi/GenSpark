using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Interfaces
{
    public interface IRequestService
    {
        public Task<Request> Add(GetRequestDto request);
        public Task<IEnumerable<Request>> Get();
    }
}
