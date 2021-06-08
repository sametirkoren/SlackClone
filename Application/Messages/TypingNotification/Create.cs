using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Messages.TypingNotification
{
    public class Create
    {
        public class Command : IRequest<TypingNotificationDto>{
            public Guid ChannelId {get;set;}
        }

        public class Handler : IRequestHandler<Command, TypingNotificationDto>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            public Handler(DataContext context , IUserAccessor userAccessor ,  IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }
            public async Task<TypingNotificationDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x=>x.UserName == _userAccessor.GetCurrentUserName());
                var channel = await _context.Channels.SingleOrDefaultAsync(x=>x.Id == request.ChannelId);
                if(channel == null){
                    throw new RestException(HttpStatusCode.NotFound , new {channel = "Kanal Bulunamadı"});
                }   

                var typing = new Domain.TypingNotification{
                    Channel = channel,
                    Sender = user
                };

                _context.TypingNotification.Add(typing);

                if(await _context.SaveChangesAsync() > 0){
                    return _mapper.Map<Domain.TypingNotification , TypingNotificationDto>(typing);
                }


                throw new Exception("Kaydederken Hata Oluştu");
            }
        }
    }
}