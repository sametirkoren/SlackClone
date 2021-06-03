using System;
using Domain;

namespace Application.Messages
{
    public class MessageDto
    {
        public string Content{get;set;}
        public DateTime CreatedAt {get;set;}

        public Application.User.UserDto Sender {get;set;}

        public MessageType MessageType {get;set;}
    }
}