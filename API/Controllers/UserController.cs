using System.Threading.Tasks;
using Application.User;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [AllowAnonymous]
    public class UserController : BaseController
    {
        [HttpPost("login")]
        public async Task<ActionResult<User>>  Login(Login.Query query){
                return await Mediator.Send(query);
        }  


        [HttpPost("register")]

        public async Task<ActionResult<User>> Register(Register.Command command){
            return await Mediator.Send(command);
        }
    }
}