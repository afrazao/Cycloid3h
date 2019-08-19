using Cycloid.Managers;
using Cycloid.Models;
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
    /// The program controller
    /// </summary>
    [RoutePrefix("v1/programs")]
    public class ProgramsController : ApiController
    {
        //private readonly IProgramsManager _programsManager;
        public Program getProgram;
        public string programToSend;

        public string programsListToSend;
            
        /// <summary>
        /// The Programs Controller constructor
        /// </summary>
        /// <param name="programsManager"></param>
        public ProgramsController(/*IProgramsManager programsManager*/)
        {
            //_programsManager = programsManager;
        }

        /// <summary>
        /// Gets the program
        /// </summary>
        /// <param name="id">The program id</param>
        /// <returns>The program</returns>
        [HttpGet]
        [ResponseType(typeof(Program))]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get([FromUri]string id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://tomahawk.cycloid.pt/ott.programs/");
                    //HTTP GET
                    var responseTask = client.GetAsync("programs");
                    responseTask.Wait();

                    var resultToRead = responseTask.Result;

                    var result = await resultToRead.Content.ReadAsStringAsync();

                    var programGot = JsonConvert.DeserializeObject<List<Program>>(result);

                    //Teste de Ids
                    var firstId = programGot[0].Id.ToString();

                    foreach (var p in programGot)
                    {
                        if (p.Id == firstId)
                        {
                            getProgram = p;
                        }
                    }

                    programToSend = JsonConvert.SerializeObject(getProgram);

                    if (programToSend != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, programToSend);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Channels Not Found");
                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the programs by channel id
        /// </summary>
        /// <param name="channelId">The channel id</param>
        /// <param name="skip">The number of elements to skip</param>
        /// <param name="take">The number of elements to take</param>
        /// <returns>The programs list</returns>
        [HttpGet]
        [ResponseType(typeof(List<Program>))]
        [Route("{channelId}")]
        public async Task<HttpResponseMessage> GetByChannel([FromUri]string channelId, [FromUri]int skip = 0, [FromUri]int take = 10)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://tomahawk.cycloid.pt/ott.programs/");

                    var responseTask = client.GetAsync("programs");
                    responseTask.Wait();

                    var resultToRead = responseTask.Result;

                    var result = await resultToRead.Content.ReadAsStringAsync();

                    var programsListGot = JsonConvert.DeserializeObject<List<Program>>(result);

                    var getProgramsList = new List<Program>();

                    //Teste de Ids
                    var firstChannelId = programsListGot[0].ChannelId.ToString();

                    foreach (var p in programsListGot)
                    {
                        if (p.ChannelId == firstChannelId)
                        {
                            getProgramsList.Add(p);
                        }
                    }

                    programsListToSend = JsonConvert.SerializeObject(getProgramsList);
                }
                if (programsListToSend != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, programsListToSend);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Programs List By Channel Not Found");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

            throw new NotImplementedException();
        }
    }
}
