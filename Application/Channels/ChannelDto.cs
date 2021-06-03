using System;
using System.Collections.Generic;
using Application.Messages;

namespace Application.Channels
{
    public class ChannelDto
    {
        public Guid Id {get;set;}
        public string Name {get;set;}

        public string Description {get;set;}

        public ICollection<MessageDto> Messages{get;set;}


    }
}