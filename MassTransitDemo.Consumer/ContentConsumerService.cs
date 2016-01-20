using System;
using MassTransit;
using Topshelf;

namespace MassTransitDemo.Consumer
{
    public class ContentConsumerService : ServiceControl
    {
        private IBusControl _bus;

        public bool Start(HostControl hostControl)
        {
            _bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "checkin", e => { e.Consumer<CheckinCommandConsumer>(); });
            });

            _bus.Start();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _bus.Stop();

            return true;
        }
    }
}