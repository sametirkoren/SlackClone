using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Channels
{
   
        public class CreateChannelCommand : IRequest{
            public Guid Id {get;set;}
            public string Name {get;set;}
            public string Description {get;set;}

            public ChannelType ChannelType {get;set;} = ChannelType.Channel;
        }

        public class CommandValidator : AbstractValidator<CreateChannelCommand>{
            public CommandValidator()
            {
                RuleFor(x=>x.Name).NotEmpty();
                RuleFor(x=>x.Description).NotEmpty();
            }
        }
        public class CreateChannelCommandHandler : IRequestHandler<CreateChannelCommand>
        {
             private DataContext _context;
            public CreateChannelCommandHandler(DataContext context){
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public  async Task<Unit> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
            {
                var channel = new Channel
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    ChannelType = request.ChannelType

                };

                _context.Channels.Add(channel);
                var success = await _context.SaveChangesAsync() > 0;
                if(success)
                    return Unit.Value;

                throw new Exception("Veri kaydedilirken bir sorun oluştu");
                
            }
        }
    }
