using AutoMapper;
using Domain;

namespace Application.User
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser,UserDto>();
        }
    }
}