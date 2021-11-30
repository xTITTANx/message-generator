using MessageGenerator.Hubs;
using MessageGenerator.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MessageGenerator
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IHubContext<MessageHub> _hubContext;

        private readonly List<Message> list;

        public MessageRepository(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
            list = new List<Message>();
        }

        public async Task<Message> Generate()
        {
            var generateText = "Test message";

            var message = new Message
            {
                ID = Guid.NewGuid(),
                Text = generateText,
                Date = DateTime.Now,
            };
            list.Add(message);

            await _hubContext.Clients.All.SendCoreAsync(nameof(IMessageHubClient.MessageSent), new object[] { message });

            return message;
        }

        public List<Message> GetAll()
        {
            return list;
        }
    }
}
