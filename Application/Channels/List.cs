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
 
        public class ListChannelQuery : IRequest<List<Channel>>
        {
            public ChannelType ChannelType {get;set;} = ChannelType.Channel;
        }

        public class ListChannelQueryHandler : IRequestHandler<ListChannelQuery, List<Channel>>
        {
            private DataContext _context;
            public ListChannelQueryHandler(DataContext context){
                _context = context ?? throw new ArgumentNullException(nameof(context));
            }
            public async Task<List<Channel>> Handle(ListChannelQuery request, CancellationToken cancellationToken)
            {
                
                return await _context.Channels.Where(x=>x.ChannelType == request.ChannelType).ToListAsync();
            }
        }
    
}