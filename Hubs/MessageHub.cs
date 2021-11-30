using MessageGenerator.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessageGenerator.Hubs
{
    public class MessageHub : Hub<IMessageHubClient>
    {
        public void MessageSent(Message message)
        {
            Clients.All.MessageSent(message);
        }
    }
}
