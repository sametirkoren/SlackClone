using AutoMapper;
using Domain;

namespace Application.Channels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Channel , ChannelDto>();
        }   
    }
}