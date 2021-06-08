using System;
using System.Collections.Generic;
using System.Linq;
using Application.Messages;
using Domain;

namespace Application.Channels
{
    public class ChannelDto
    {
        private IEnumerable<MessageDto> _messages;
        public Guid Id {get;set;}
        public string Name {get;set;}

        public string Description {get;set;}

        public IEnumerable<MessageDto> Messages{
            get
            { 
                return _messages.OrderBy(x=>x.CreatedAt);
            }
            set{
                _messages = value;
            }
            }

        public string PrivateChannelId{get;set;}

        public ChannelType ChannelType {get;set;}

        public Guid ChannelId {get;set;}



    }
}