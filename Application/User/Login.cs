using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<User>{
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
        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            public Handler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager , IJwtGenerator jwtGenerator)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }
            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if(user == null){
                    throw new RestException(HttpStatusCode.Unauthorized);
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);

                if(result.Succeeded){
                    return new User{
                        Token=_jwtGenerator.CreateToken(user),
                        UserName = user.UserName,
                        Email = user.Email
                    };
                }

                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}