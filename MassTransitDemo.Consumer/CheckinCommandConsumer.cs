using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitDemo.Contracts;

namespace MassTransitDemo.Consumer
{
    public class CheckinCommandConsumer : IConsumer<CheckinCommand>
    {
        public Task Consume(ConsumeContext<CheckinCommand> context)
        {
            var command = context.Message;

            Console.WriteLine("Consuming CheckinCommand " + command.Id);

            context.Publish<CheckinCompletedEvent>(new
            {
                command.Id,
                IsOk = DateTime.Now.Millisecond%2 == 0
            });

            return Task.FromResult(0);
        }
    }
}