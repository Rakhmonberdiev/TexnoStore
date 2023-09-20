using AutoMapper;
using TenoStore.API.Dtos;
using TexnoStore.Core.Entities;

namespace TenoStore.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>();
        }
    }
}
