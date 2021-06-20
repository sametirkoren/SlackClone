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

        public class UserLoginQuery : IRequest<UserDto>{
            public string Email{get;set;}
            public string Password {get;set;}
        }

        public class QueryValidator : AbstractValidator<UserLoginQuery>{
           
           public QueryValidator()
           {
                RuleFor(x=>x.Email).NotEmpty();
                RuleFor(x=>x.Password).NotEmpty();
           }
        }
        public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly DataContext _context;
            public UserLoginQueryHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager , IJwtGenerator jwtGenerator , DataContext context)
            {
                _signInManager = signInManager;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
                _context = context;
                
            }
            public async Task<UserDto> Handle(UserLoginQuery request, CancellationToken cancellationToken)
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