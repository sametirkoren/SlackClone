using System;
using System.Collections.Generic;

namespace Domain{
    public class Channel{
        public Guid Id{get;set;}
        public string Name {get;set;}
        public string Description {get;set;}

        public ICollection<Message> Messages {get;set;}

        public ChannelType ChannelType {get;set;}

    }
}