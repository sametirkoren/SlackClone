using System.Threading.Tasks;
using API.SignalR;
using Application.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Controllers
{
    public class MessagesController : BaseController
    {
        private readonly IHubContext<ChatHub> _hubContext;
        public MessagesController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpPost]

        public async Task<ActionResult<MessageDto>> Create(Application.Messages.Create.Command command){
            return await Mediator.Send(command);
        }

        [HttpPost("upload")]
        public async Task<ActionResult<MessageDto>> MediaUpload([FromForm] Application.Messages.Create.Command command){
           var result = await Mediator.Send(command);
           await _hubContext.Clients.All.SendAsync("ReceiveMessage",result);
           return result;
        }
    }
}