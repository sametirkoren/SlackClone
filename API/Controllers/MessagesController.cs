using System.Threading.Tasks;
using Application.Messages;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MessagesController : BaseController
    {
        [HttpPost]

        public async Task<ActionResult<MessageDto>> Create(Application.Messages.Create.Command command){
            return await Mediator.Send(command);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<MessageDto>> MediaUpload([FromForm] Application.Messages.Create.Command command){
            return await Mediator.Send(command);
        }
    }
}