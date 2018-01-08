using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataFlow.Common.DAL;
using DataFlow.Models;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using DataFlow.Web.Areas.Api.Models;
using DataFlow.Web.Services;
using NLog;

namespace DataFlow.Web.Areas.Api.Controllers
{
    [AllowAnonymous]
    public class ChromeExtensionController : ApiController
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register([FromBody] AgentMessage message)
        {
            try
            {
                using (var ctx = new DataFlowDbContext())
                {
                    AgentChrome chrome = ctx.AgentChromes.FirstOrDefault(ac => ac.AgentUuid == message.uuid);

                    if (chrome != null)
                    {
                        _logger.Error(String.Format("Duplicate Chrome Agent registration requested for uuid = {0}", message.uuid));
                        return new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.BadRequest
                    };
                    }
                    else
                    {
                        chrome = new AgentChrome();
                        chrome.AgentUuid = message.uuid;
                        chrome.AccessToken = Guid.NewGuid();
                        chrome.Created = DateTime.Now;
                        ctx.AgentChromes.Add(chrome);
                        ctx.SaveChanges();
                        message.token = chrome.AccessToken;
                        _logger.Info(String.Format("Registered new Chrome Agent with uuid = {0}", message.uuid));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error in Register");

                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return Request.CreateResponse((HttpStatusCode)200, message);
        }

        [HttpPost]
        [Route("api/agents")]
        public List<AgentResponse> Agents([FromBody] AgentMessage message)
        {
            List<AgentResponse> response = new List<AgentResponse>();

            try
            {
                using (var ctx = new DataFlowDbContext())
                {
                    AgentChrome agentChrome = ctx.AgentChromes.Where(ac => ac.AgentUuid == message.uuid && ac.AccessToken == message.token).FirstOrDefault();
                    if (agentChrome != null)
                    {
                        List<AgentAgentChrome> agentAgentChromes = ctx.AgentAgentChromes.Where(aacc => aacc.AgentChromeId == agentChrome.Id).Include(aacc => aacc.Agent.AgentSchedules).ToList();

                        foreach (var agentAgentChrome in agentAgentChromes)
                        {
                            AgentResponse responseAgent = new AgentResponse();
                            responseAgent.agent_id = agentAgentChrome.Agent.Id;
                            responseAgent.name = agentAgentChrome.Agent.Name;
                            responseAgent.action = agentAgentChrome.Agent.AgentAction;
                            responseAgent.parameters = agentAgentChrome.Agent.Custom;
                            responseAgent.url = agentAgentChrome.Agent.Url;
                            responseAgent.loginUrl = agentAgentChrome.Agent.LoginUrl;
                            responseAgent.schedule = new List<AgentScheduleResponse>();

                            foreach (var sch in agentAgentChrome.Agent.AgentSchedules)
                            {
                                AgentScheduleResponse schedule = new AgentScheduleResponse(sch.Day, sch.Hour, sch.Minute);
                                responseAgent.schedule.Add(schedule);
                            }

                            response.Add(responseAgent);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex, "Unexpected error in Agents");
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return response;
        }

        [HttpPost]
        [Route("api/data")]
        public HttpResponseMessage Data([FromBody] AgentMessage message)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            try
            {
                using (var ctx = new DataFlowDbContext())
                {
                    Agent agent = GetAgent(message.uuid, message.token, message.agent_id);

                    if (agent != null && message.data != null && message.filename != null)
                    {
                        byte[] dataArray = Convert.FromBase64String(message.data);

                        if (dataArray != null)
                        {
                            System.IO.MemoryStream stream = new System.IO.MemoryStream(dataArray);
                            AgentService svc = new AgentService(ctx, null);
                            
                            Tuple<bool, string> result = svc.UploadFile(message.filename, stream, agent);
                            if (result.Item1)
                                statusCode = HttpStatusCode.OK;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Unexpected error in Data");
            }

            return new HttpResponseMessage()
            {
                StatusCode = statusCode
            };
        }

        [HttpPost]
        [Route("api/log")]
        public HttpResponseMessage Log([FromBody] AgentMessage message)
        {
            Agent agent = GetAgent(message.uuid, message.token, message.agent_id);
            if (agent != null)
            {
                _logger.Info(String.Format("Agent UUID={0} for agent_id: {1},  logs: {2}", message.uuid, message.agent_id, message.message));
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }

        // This method validates the uuid and token is related to the agent, if so, return the agent object
        public Agent GetAgent(Guid uuid, Guid token, int agent_id)
        {
            Agent returnAgent = null;

            using (var ctx = new DataFlowDbContext())
            {
                AgentChrome chrome = ctx.AgentChromes.Where(ac => ac.AgentUuid == uuid && ac.AccessToken == token).FirstOrDefault();
                if (chrome != null)
                { 
                    var aac = ctx.AgentAgentChromes.Where(aacc => aacc.AgentChromeId == chrome.Id && aacc.AgentId == agent_id).Include(aacc => aacc.Agent.AgentSchedules).FirstOrDefault();
                    if (aac != null && aac.Agent != null)
                        returnAgent = aac.Agent;
                }
            }

            return returnAgent;
        }
    }
}
