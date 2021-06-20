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
        public async Task SendMessage(CreateMessageCommand command){
            var message = await _mediator.Send(command);

            await Clients.All.SendAsync("ReceiveMessage",message);
        }

         public async Task
        SendTypingNotification(
            Application.Messages.TypingNotification.Create.Command command
        )
        {
            var typing = await _mediator.Send(command);

            await Clients.All.SendAsync("ReceiveTypingNotification", typing);
        }

        public async Task DeleteTypingNotification()
        {
            var typing =
                await _mediator
                    .Send(new Application.Messages.TypingNotification.Delete.Command());

            await Clients
                .All
                .SendAsync("ReceiveDeleteTypingNotification", typing);
        }
    }
}