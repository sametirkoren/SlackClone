using Application.Channels;
using Application.User;

namespace Application.Messages.TypingNotification
{
    public class TypingNotificationDto
    {
        public UserDto Sender{get;set;}

        public ChannelDto Channel {get;set;}
    }
}