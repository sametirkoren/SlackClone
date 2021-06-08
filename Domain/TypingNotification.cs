using System;

namespace Domain
{
    public class TypingNotification
    {
        public string Id {get;set;}

        public Channel Channel {get;set;}

        public Guid ChannelId {get;set;}

        public AppUser Sender{get;set;}
    }
}