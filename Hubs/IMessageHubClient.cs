using MessageGenerator.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessageGenerator.Hubs
{
    public interface IMessageHubClient : IClientProxy
    {
        void MessageSent(Message message);
    }
}
