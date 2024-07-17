using API.Models;
using API.Models.Dtos;
using AutoMapper;

namespace API.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<Product, ProductDto>().ReverseMap();
            #endregion
        }
    }
}