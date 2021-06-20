using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Messages
{
   
   
        public class CreateMessageCommand : IRequest<MessageDto>{
            public string Content{get;set;}

            public Guid ChannelId {get;set;}

            public MessageType MessageType {get;set;} = MessageType.Text;

            public IFormFile File {get;set;}
        }

        public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, MessageDto>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            private readonly IMapper _mapper;
            private readonly IMediaUpload _mediaUpload;
            public CreateMessageCommandHandler(DataContext context, IUserAccessor userAccessor, IMapper mapper, IMediaUpload mediaUpload )
            {
                _context = context;
                _userAccessor = userAccessor;
                _mapper = mapper;
                _mediaUpload = mediaUpload;
            }
            public async Task<MessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x=>x.UserName == _userAccessor.GetCurrentUserName());
                var channel = await _context.Channels.SingleOrDefaultAsync(x=>x.Id == request.ChannelId);


                if(channel == null){
                    throw new RestException(HttpStatusCode.NotFound , new {channel = "Kanal Bulunamadı"});
                }

                var message = new Message{
                    Content = request.MessageType == MessageType.Text ? request.Content : _mediaUpload.UploadMedia(request.File).Url,
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
                            Avatar = user.Avatar,
                            Email = user.Email,
                            Id = user.Id,
                            IsOnline = user.IsOnline
                        },
                        ChannelId = message.ChannelId,
                        Content = message.Content,
                        CreatedAt = message.CreatedAt,
                        MessageType = message.MessageType
                    };
                }

                throw new Exception("Mesaj eklenirken bir sorun oluştu.");
            }


            
        }
    }
