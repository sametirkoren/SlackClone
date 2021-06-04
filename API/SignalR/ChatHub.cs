using System.Threading.Tasks;
using Application.Messages;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class ChatHub : Hub
    {
        private readonly IMediator _mediator;

        public ChatHub(IMediator meditor)
        {
            _mediator = meditor;
        }
        public async Task SendMessage(Create.Command command){
            var message = await _mediator.Send(command);

            await Clients.All.SendAsync("ReceiveMessage",message);
        }
    }
}