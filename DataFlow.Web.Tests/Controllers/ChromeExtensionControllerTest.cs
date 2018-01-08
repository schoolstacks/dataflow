using System;
using System.Linq;
using System.Configuration;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataFlow.Common.DAL;
using DataFlow.Common.Helpers;
using DataFlow.Models;
using DataFlow.Web.Areas.Api.Controllers;
using DataFlow.Web.Areas.Api.Models;


namespace DataFlow.Web.Tests.Controllers
{
    [TestClass]
    public class ChromeExtensionControllerTest
    {
        static Guid _agentGuid;
        static Guid _agentToken;
        static int _agentId;
        static int _agentAgentChromeId;
        static int _agentChromeId;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            using (var ctx = new DataFlowDbContext())
            {
                Agent agent = new Agent();
                agent.AgentTypeCode = Common.Enums.AgentTypeCodeEnum.Chrome;
                agent.Name = "Unit Test Chrome Agent";
                agent.Enabled = true;
                agent.Queue = Guid.NewGuid();
                agent.Created = DateTime.Now;

                ctx.Agents.Add(agent);
                ctx.SaveChanges();

                _agentId = agent.Id;
            }
        }

        [TestMethod]
        public void RegisterAgent()
        {
            ChromeExtensionController cec = new ChromeExtensionController();
            cec.Request = new HttpRequestMessage();
            cec.Request.SetConfiguration(new HttpConfiguration());

            AgentMessage message = new AgentMessage();
            message.uuid = Guid.NewGuid();

            HttpResponseMessage response = cec.Register(message);
            var content = response.Content;
            Assert.IsNotNull(content);
            Assert.IsInstanceOfType(content, typeof(ObjectContent<AgentMessage>));
            AgentMessage responseMessage = (AgentMessage)((ObjectContent<AgentMessage>)content).Value;
            Assert.IsNotNull(responseMessage.token);
            Assert.AreNotEqual(Guid.Parse("00000000-0000-0000-0000-000000000000"), responseMessage.token);
            _agentGuid = responseMessage.uuid;
            _agentToken = responseMessage.token;

            // If we've gotten this far, we've registered a new AgentChrome, let's associate it with the agent
            using (var ctx = new DataFlowDbContext())
            {
                AgentChrome ac = ctx.AgentChromes.Where(chr => chr.AgentUuid == _agentGuid && chr.AccessToken == _agentToken).FirstOrDefault();
                AgentAgentChrome aac = new AgentAgentChrome();
                aac.AgentChromeId = ac.Id;
                aac.AgentId = _agentId;
                ctx.AgentAgentChromes.Add(aac);
                ctx.SaveChanges();
                _agentChromeId = ac.Id;
                _agentAgentChromeId = aac.Id;
            }
            
        }

        [TestMethod]
        public void SendData()
        {
            ChromeExtensionController cec = new ChromeExtensionController();
            cec.Request = new HttpRequestMessage();
            cec.Request.SetConfiguration(new HttpConfiguration());

            byte[] fileContents = System.IO.File.ReadAllBytes(@".\TestData\sample.csv");
            Assert.IsNotNull(fileContents);

            AgentMessage message = new AgentMessage();
            message.uuid = _agentGuid;
            message.token = _agentToken;
            message.agent_id = _agentId;
            message.filename = "sample.csv";
            message.data = Convert.ToBase64String(fileContents);

            HttpResponseMessage response = cec.Data(message);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            using (var ctx = new DataFlowDbContext())
            {
                AgentAgentChrome aac = ctx.AgentAgentChromes.Find(_agentAgentChromeId);
                ctx.AgentAgentChromes.Remove(aac);

                AgentChrome chrome = ctx.AgentChromes.Find(_agentChromeId);
                ctx.AgentChromes.Remove(chrome);

                Agent agent = ctx.Agents.Find(_agentId);
                // Remove the directory with the agent temp file sample.csv
                System.IO.Directory.Delete(PathUtility.EnsureTrailingSlash(ConfigurationManager.AppSettings["ShareName"]) + agent.Queue.ToString(), true);
                ctx.Agents.Remove(agent);

                ctx.SaveChanges();
            }
        }
    }
}
