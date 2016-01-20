using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MassTransitDemo.Web.Api;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace MassTransitDemo.Web.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MessageBusConfig.Configure();
        }
    }
}