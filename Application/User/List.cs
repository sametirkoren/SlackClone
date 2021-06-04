using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.User
{
    public class List
    {
        public class Query : IRequest<List<UserDto>>{

        }

        public class Handler : IRequestHandler<Query, List<UserDto>>
        {


            private readonly DataContext _context;
            private readonly IMapper _mapper;

       
            public Handler(DataContext context , IMapper mapper)
            {
                _mapper =mapper;
                _context =context;
            }
            public async Task<List<UserDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.ToListAsync();

                var userToReturn = _mapper.Map<IEnumerable<AppUser>,List<UserDto>>(users);

                return userToReturn;
            }
        }
    }
}