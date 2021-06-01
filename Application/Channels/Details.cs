using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;

namespace Application.Channels
{
    public class Details
    {
        public class Query : IRequest<Channel>
        {
            public Guid Id {get;set;}
        }

        public class Handler : IRequestHandler<Query, Channel>
        {
            public async Task<Channel> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}