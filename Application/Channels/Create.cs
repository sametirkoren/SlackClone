using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Channels
{
    public class Create
    {
        public class Command : IRequest{
            public Guid Id {get;set;}
            public string Name {get;set;}
            public string Description {get;set;}
        }

        public class CommandValidator : AbstractValidator<Command>{
            public CommandValidator()
            {
                RuleFor(x=>x.Name).NotEmpty();
                RuleFor(x=>x.Description).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command>
        {
             private DataContext _context;
            public Handler(DataContext context){
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public  async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var channel = new Channel
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    ChannelType = ChannelType.Channel

                };

                _context.Channels.Add(channel);
                var success = await _context.SaveChangesAsync() > 0;
                if(success)
                    return Unit.Value;

                throw new Exception("Veri kaydedilirken bir sorun oluştu");
                
            }
        }
    }
}