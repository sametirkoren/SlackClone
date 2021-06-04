using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.User
{
    public class Logout
    {
        public class Query : IRequest{
            public string UserId {get;set;}
        }

        public class Handler : IRequestHandler<Query>
        {

            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Query request, CancellationToken cancellationToken)
            {
               var user = await _context.Users.FindAsync(request.UserId);

               if(user == null){
                   throw new RestException(HttpStatusCode.NotFound);
               }
               
               if(!user.IsOnline) return Unit.Value;

               user.IsOnline = false;

               var success = await _context.SaveChangesAsync() > 0;

               if(success) return Unit.Value;

               throw new Exception("Hata");
            }
        }
    }
}