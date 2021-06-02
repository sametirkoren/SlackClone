using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<User>{

            public string UserName {get;set;}
            public string Email {get;set;}

            public string Password {get;set;}


        }

        public class CommandValidator : AbstractValidator<Command>{
            private readonly UserManager<AppUser> userManager;
            public CommandValidator(UserManager<AppUser> userManager)
            {
                RuleFor(x=>x.UserName).NotEmpty()
                    .MustAsync(async (username , cancellation) => (await userManager.FindByNameAsync(username)) == null)
                    .WithMessage("Bu Kullanıcı adı zaten mevcut.");
                RuleFor(x=>x.Email).NotEmpty()
                    .EmailAddress()
                    .MustAsync(async (email , cancellation) => (await userManager.FindByNameAsync(email)) == null)
                    .WithMessage("Bu email zaten mevcut.");;
                RuleFor(x=>x.Password).Password();
            }
        }

        public class Handler : IRequestHandler<Command, User>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(UserManager<AppUser> userManager , IJwtGenerator jwtGenerator)
            {
                _jwtGenerator = jwtGenerator;
                _userManager = userManager;
            }
            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
               

                var user = new AppUser{
                    Email = request.Email,
                    UserName = request.UserName
                };

                var result = await _userManager.CreateAsync(user,request.Password);

                if(result.Succeeded){
                    return new User{
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _jwtGenerator.CreateToken(user)
                    };
                }

                throw new Exception("Kullanıcı kayıt olurken hata");
            }
        }
    }
}