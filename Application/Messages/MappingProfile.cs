using Application.Messages.TypingNotification;
using AutoMapper;
using Domain;

namespace Application.Messages
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message,MessageDto>();

            CreateMap<Channel,MessageDto>().ForMember(d=>d.ChannelId , o=> o.MapFrom(s=>s.Id));

            CreateMap<Domain.TypingNotification , TypingNotificationDto>();
        }
    }
}