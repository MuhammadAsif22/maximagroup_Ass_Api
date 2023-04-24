using AutoMapper;
using eServicesApi.Data;
using eServicesApi.Model;

namespace eServicesApi.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
