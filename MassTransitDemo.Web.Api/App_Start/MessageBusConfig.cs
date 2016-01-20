using System;
using System.Collections.Generic;
using MassTransit;
using MassTransitDemo.Web.Api.Consumers;
using MassTransitDemo.Web.Api.ViewModels;

namespace MassTransitDemo.Web.Api
{
    public class MessageBusConfig
    {
        public static IBusControl BusControl { get; set; }
        public static IList<CheckinResult> CheckinResults { get; set; }

        public static void Configure()
        {
            CheckinResults = new List<CheckinResult>();

            BusControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                #region ...

                cfg.ReceiveEndpoint(host, e => { e.Consumer<CheckinCompletedEventConsumer>(); });

                #endregion
            });

            BusControl.Start();
        }
    }
}