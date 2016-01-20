using Topshelf;

namespace MassTransitDemo.Consumer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(cfg => { cfg.Service(x => new ContentConsumerService()); });
        }
    }
}