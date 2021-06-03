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
        public async Task<ActionResult<UserDto>>  Login(Login.Query query){
                return await Mediator.Send(query);
        }  


        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register(Register.Command command){
            return await Mediator.Send(command);
        }


         [HttpGet]

         public async Task<ActionResult<UserDto>> CurrentUser(){
             return await Mediator.Send(new CurrentUser.Query());
         }
    }
}