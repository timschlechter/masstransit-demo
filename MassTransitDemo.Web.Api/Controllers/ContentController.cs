using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MassTransitDemo.Contracts;

namespace MassTransitDemo.Web.Api.Controllers
{
    public class ContentController : ApiController
    {
        private static int _seqNr;

        [Route("Content/Checkin/{id}")]
        [HttpPost]
        public async Task<HttpResponseMessage> Checkin([FromUri] string id)
        {
            var endpoint = await MessageBusConfig.BusControl.GetSendEndpoint(new Uri("rabbitmq://localhost/checkin"));

            await endpoint.Send<CheckinCommand>(new
            {
                Id = id
            });

            return Request.CreateResponse(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        [Route("Content/Checkins")]
        [HttpGet]
        public HttpResponseMessage GetCheckins()
        {
            return Request.CreateResponse(HttpStatusCode.OK, MessageBusConfig.CheckinResults);
        }
    }
}