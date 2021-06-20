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
          public class UserListQuery : IRequest<List<UserDto>>{

        }

        public class UserListQueryHandler : IRequestHandler<UserListQuery, List<UserDto>>
        {


            private readonly DataContext _context;
            private readonly IMapper _mapper;

       
            public UserListQueryHandler(DataContext context , IMapper mapper)
            {
                _mapper =mapper;
                _context =context;
            }
            public async Task<List<UserDto>> Handle(UserListQuery request, CancellationToken cancellationToken)
            {
                var users = await _context.Users.ToListAsync();

                var userToReturn = _mapper.Map<IEnumerable<AppUser>,List<UserDto>>(users);

                return userToReturn;
            }
        }
    
}