using System.Threading.Tasks;
using MassTransit;
using MassTransitDemo.Contracts;
using MassTransitDemo.Web.Api.ViewModels;

namespace MassTransitDemo.Web.Api.Consumers
{
    public class CheckinCompletedEventConsumer : IConsumer<CheckinCompletedEvent>
    {
        public Task Consume(ConsumeContext<CheckinCompletedEvent> context)
        {
            var checkinCompleted = context.Message;

            MessageBusConfig.CheckinResults.Add(new CheckinResult
            {
                ContentId = checkinCompleted.Id,
                Result = checkinCompleted.IsOk ? "OK" : "FAILED"
            });

            return Task.FromResult(0);
        }
    }
}