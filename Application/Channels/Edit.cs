using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Channels
{
  
        public class UpdateChannelCommand : IRequest{
            public Guid Id {get;set;}

            public string Name {get;set;}

            public string Description {get;set;}

            public ChannelType ChannelType {get;set;} = ChannelType.Channel;
        }

        public class UpdateChannelCommandHandler : IRequestHandler<UpdateChannelCommand>
        {
            private readonly DataContext _context;
            public UpdateChannelCommandHandler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateChannelCommand request, CancellationToken cancellationToken)
            {
                var channel = await _context.Channels.FindAsync(request.Id);

                if(channel == null) {
                    throw new RestException(HttpStatusCode.NotFound,new {Channel = "Kanal bulunamadı"});
                }

                channel.ChannelType = request.ChannelType;
                channel.Name = request.Name ?? channel.Name;
                channel.Description = request.Description ?? channel.Description;

                var success = await _context.SaveChangesAsync() > 0 ;

                if(success) return Unit.Value;

                throw new Exception("Kanal Güncellerken Hata");
            }
        }
    }
