using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly IMessageRepository _messageRepository;
        private Timer _timer;

        public TimedHostedService(IMessageRepository messageRepository)
        {
            _messageRepository= messageRepository;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(3));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _messageRepository.Generate();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
