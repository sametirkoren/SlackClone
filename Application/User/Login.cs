using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<UserDto>{
            public string Email{get;set;}
            public string Password {get;set;}
        }

        public class QueryValidator : AbstractValidator<Query>{
           
           public QueryValidator()
           {
                RuleFor(x=>x.Email).NotEmpty();
                RuleFor(x=>x.Password).NotEmpty();
           }
        }
        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly DataContext _context;
            public Handler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager , IJwtGenerator jwtGenerator , DataContext context)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
                _context = context;
                
            }
            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user == null){
                    throw new RestException(HttpStatusCode.Unauthorized);
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);

                if(result.Succeeded){
                    user.IsOnline  = true;
                    await _context.SaveChangesAsync();
                    return new UserDto{
                        Token=_jwtGenerator.CreateToken(user),
                        UserName = user.UserName,
                        Email = user.Email,
                        Id = user.Id,
                        IsOnline = user.IsOnline,
                        Avatar = user.Avatar
                    };
                }

                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}