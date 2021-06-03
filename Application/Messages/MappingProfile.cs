using AutoMapper;
using Domain;

namespace Application.Messages
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message,MessageDto>();
        }
    }
}