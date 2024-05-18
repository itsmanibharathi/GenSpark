using AutoMapper;
using EmployeeRequestTracker.Models;
using EmployeeRequestTracker.Models.ModelsDTOs;

namespace EmployeeRequestTracker.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, ReturnEmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
