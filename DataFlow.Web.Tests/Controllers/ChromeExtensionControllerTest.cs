using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataFlow.Common;
using DataFlow.Common.DAL;
using DataFlow.Models;
using DataFlow.Web.Areas.Api.Controllers;
using DataFlow.Web.Areas.Api.Models;


namespace DataFlow.Web.Tests.Controllers
{
    [TestClass]
    public class ChromeExtensionControllerTest
    {
        static Guid agentGuid;
        static Guid agentToken;
        static int agentId;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            using (var ctx = new DataFlowDbContext())
            {
                Agent agent = new Agent();
                agent.AgentTypeCode = Common.Enums.AgentTypeCodeEnum.Chrome;
                agent.Name = "Unit Test Chrome Agent";
                agent.Enabled = true;
                agent.Created = DateTime.Now;

                ctx.Agents.Add(agent);
                ctx.SaveChanges();

                agentId = agent.Id;
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
            agentGuid = responseMessage.uuid;
            agentToken = responseMessage.token;
        }

        [TestMethod]
        public void SendData()
        {
            ChromeExtensionController cec = new ChromeExtensionController();
            cec.Request = new HttpRequestMessage();
            cec.Request.SetConfiguration(new HttpConfiguration());

            AgentMessage message = new AgentMessage();
            HttpResponseMessage response = cec.Register(message);

            message.uuid = agentGuid;
            message.token = agentToken;
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            using (var ctx = new DataFlowDbContext())
            {
                AgentChrome chrome = ctx.AgentChromes.Where(ac => ac.AgentUuid == agentGuid && ac.AccessToken == agentToken).FirstOrDefault();
                ctx.AgentChromes.Remove(chrome);

                Agent agent = ctx.Agents.Find(agentId);
                ctx.Agents.Remove(agent);

                ctx.SaveChanges();
            }
        }
    }
}
