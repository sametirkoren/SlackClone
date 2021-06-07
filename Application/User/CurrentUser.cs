using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<UserDto>{

        }

        public class Handler : IRequestHandler<Query, UserDto>
        {

            private readonly IUserAccessor _userAccessor;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;
            public Handler(IUserAccessor userAccessor , UserManager<AppUser> userManager , IJwtGenerator jwtGenerator)
            {
                _userAccessor = userAccessor;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }
            public  async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userAccessor.GetCurrentUserName());
                return new UserDto{
                    UserName = user.UserName,
                    Token = _jwtGenerator.CreateToken(user),
                    Email = user.Email,
                    Id = user.Id,
                    Avatar = user.Avatar
                };
            }
        }
    }
}