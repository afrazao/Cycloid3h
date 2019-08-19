using Cycloid.Common.ParameterBinding;
using Cycloid.Managers;
using Cycloid.Models;
using Cycloid.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Cycloid.API.Controllers
{
    /// <summary>
    /// The channels controller
    /// </summary>
    [RoutePrefix("v1/channels")]
    public class ChannelsController : ApiController 
    {
        //private readonly IChannelsManager _channelsManager;

        public List<Channel> Channels;

        /// <summary>
        /// The channels controller constructor
        /// </summary>
        /// <param name="channelsManager">The channels manager</param>
        public ChannelsController(/*IChannelsManager channelsManager*/)
        {
            //_channelsManager = channelsManager;
        }

        /// <summary>
        /// Gets all channels
        /// </summary>
        /// <returns>The channels</returns>
        [HttpGet]
        [ResponseType(typeof(List<Channel>))]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                //var ChannelsList = await this._channelsManager.GetAllChannels();

                //var ChannelsList = new List<Channel>
                //{
                //    new Channel
                //    {
                //        Id = "1",
                //        Name = "TVI",
                //        Position = 31,
                //    },
                //    new Channel
                //    {
                //        Id = "2",
                //        Name = "SIC",
                //        Position = 34,
                //    },
                //};

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://tomahawk.cycloid.pt/ott.channels/Service.svc/");
                    //HTTP GET
                    var responseTask = client.GetAsync("GetChannels");
                    responseTask.Wait();

                    var resultToRead = responseTask.Result;

                    var result = await resultToRead.Content.ReadAsStringAsync();

                    Channels = JsonConvert.DeserializeObject<List<Channel>>(result);
                }

                var ChannelsList = Channels;

                if (ChannelsList != null)
                {
                    var ChannelsListToSend = JsonConvert.SerializeObject(ChannelsList);

                    return Request.CreateResponse(HttpStatusCode.OK, ChannelsListToSend);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Channels Not Found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); 
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the subscribed channels
        /// </summary>
        /// <param name="sessionId">The session id</param>
        /// <returns>The subscribed channel ids</returns>
        [HttpGet]
        [ResponseType(typeof(List<Channel>))]
        [Route("subscribed")]
        public HttpResponseMessage GetSubscribedChannels([FromHeader("session-id")]string sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
