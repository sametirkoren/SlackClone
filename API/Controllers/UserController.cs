using System.Collections.Generic;
using System.Threading.Tasks;
using Application.User;
using Domain;
using MediatR;
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

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<UserDto>>> List(){
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("logout/{id}")]
        public async Task<Unit> Logout(string id){
            return await Mediator.Send(new Logout.Query {UserId = id});
        }

    }
}