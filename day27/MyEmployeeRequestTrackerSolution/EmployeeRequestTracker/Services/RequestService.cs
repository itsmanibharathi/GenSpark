using EmployeeRequestTracker.Interfaces;
using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _repository;

        public RequestService(IRepository<int,Request> repository)
        {
            _repository = repository;
        }

        public async Task<Request> Add(GetRequestDto getRequestDto)
        {
            Request request = new Request
            {
                RaisedBy = getRequestDto.EmployeeId,
                Title = getRequestDto.RequestTitle,
                Description = getRequestDto.RequestDescription,
                Status = RequestStatus.Open
            };
            return await _repository.Add(request);
        }

        public async Task<IEnumerable<Request>> Get()
        {
            return await _repository.Get();
        }
    }
}
