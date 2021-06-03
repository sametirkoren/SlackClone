using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Messages
{
    public class Create
    {
        public class Command : IRequest<MessageDto>{
            public string Content{get;set;}

            public Guid ChannelId {get;set;}

            public MessageType MessageType {get;set;} = MessageType.Text;
        }

        public class Handler : IRequestHandler<Command, MessageDto>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context ,IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }
            public async Task<MessageDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x=>x.UserName == _userAccessor.GetCurrentUserName());
                var channel = await _context.Channels.SingleOrDefaultAsync(x=>x.Id == request.ChannelId);


                if(channel == null){
                    throw new RestException(HttpStatusCode.NotFound , new {channel = "Kanal Bulunamadı"});
                }

                var message = new Message{
                    Content = request.Content,
                    Channel = channel,
                    Sender = user,
                    CreatedAt = DateTime.Now,
                    MessageType = request.MessageType
                };

                _context.Messages.Add(message);

                if(await _context.SaveChangesAsync() > 0){
                    return new MessageDto{
                        Sender = new User.UserDto{
                            UserName = user.UserName,
                            Avatar = user.Avatar
                        },
                        Content = message.Content,
                        CreatedAt = message.CreatedAt
                    };
                }

                throw new Exception("Mesaj eklenirken bir sorun oluştu.");
            }


            
        }
    }
}