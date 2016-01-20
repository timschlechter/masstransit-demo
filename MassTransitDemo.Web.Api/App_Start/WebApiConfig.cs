using System.Web.Http;

namespace MassTransitDemo.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }
    }
}