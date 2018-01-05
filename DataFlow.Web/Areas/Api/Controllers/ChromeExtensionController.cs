using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using DataFlow.Common.DAL;
using DataFlow.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataFlow.Web.Areas.Api.Controllers
{
    [AllowAnonymous]
    public class ChromeExtensionController : ApiController
    {
        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register([FromBody] Models.AgentRegistration registration)
        {
            try
            {
                using (var ctx = new DataFlowDbContext())
                {
                    AgentChrome chrome = ctx.AgentChromes.FirstOrDefault(ac => ac.AgentUuid == registration.uuid);

                    if (chrome != null)
                        registration.token = chrome.AccessToken;
                    else
                    {
                        chrome = new AgentChrome();
                        chrome.AgentUuid = registration.uuid;
                        chrome.AccessToken = Guid.NewGuid();
                        chrome.Created = DateTime.Now;
                        ctx.AgentChromes.Add(chrome);
                        ctx.SaveChanges();
                        registration.token = chrome.AccessToken;
                        //TODO: Log success create
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO:  Log error message

                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return Request.CreateResponse((HttpStatusCode)200, registration);
        }

        [HttpPost]
        [Route("api/agents")]
        public List<Models.AgentResponse> Agents()
        {
            List<Models.AgentResponse> response = new List<Models.AgentResponse>();

            try
            {
                string request = Request.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(request);
                System.Guid uuid = System.Guid.Parse(json["uuid"].ToString());
                System.Guid token = System.Guid.Parse(json["token"].ToString());

                using (var ctx = new DataFlowDbContext())
                {
                    AgentChrome chrome = ctx.AgentChromes.Where(ac => ac.AgentUuid == uuid && ac.AccessToken == token).FirstOrDefault();
                    List<AgentAgentChrome> chromes = ctx.AgentAgentChromes.Where(aac => aac.AgentChromeId == chrome.Id).Include(aac => aac.Agent).Include("Agent.AgentSchedules").ToList();


                    foreach (var chm in chromes)
                    {
                        Models.AgentResponse responseAgent = new Models.AgentResponse();
                        responseAgent.AgentId = chm.AgentId;
                        responseAgent.Action = chm.Agent.AgentAction;
                        responseAgent.Url = chm.Agent.Url;
                        responseAgent.LoginUrl = chm.Agent.LoginUrl;
                        responseAgent.Schedule = new List<Models.AgentScheduleResponse>();

                        foreach (var sch in chm.Agent.AgentSchedules)
                        {
                            Models.AgentScheduleResponse schedule = new Models.AgentScheduleResponse(sch.Day, sch.Hour, sch.Minute);
                            responseAgent.Schedule.Add(schedule);
                        }

                        response.Add(responseAgent);
                    }
                    
                }

            } catch (System.Exception ex)
            {
                //TODO:  Log exception

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        [HttpPost]
        [Route("api/data")]
        public HttpResponseMessage Data()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPost]
        [Route("api/log")]
        public HttpResponseMessage Log()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
