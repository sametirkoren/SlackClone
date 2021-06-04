using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Channels
{
    public class List
    {
        public class Query : IRequest<List<Channel>>
        {
            public ChannelType ChannelType {get;set;} = ChannelType.Channel;
        }

        public class Handler : IRequestHandler<Query, List<Channel>>
        {
            private DataContext _context;
            public Handler(DataContext context){
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<List<Channel>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                return await _context.Channels.Where(x=>x.ChannelType == request.ChannelType).ToListAsync();
            }
        }
    }
}