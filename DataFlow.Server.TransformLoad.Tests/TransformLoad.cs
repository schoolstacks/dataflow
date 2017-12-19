using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using DataFlow.Common;
using DataFlow.Common.DAL;
using DataFlow.Common.ExtensionMethods;
using DataFlow.Models;
using DataFlow.Common.Enums;

namespace DataFlow.Server.TransformLoad.Tests
{
    [TestClass]
    public class TransformLoad
    {
        private static TestContext TestContext { get; set; }
        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            TestContext = testContext;
        }

        [TestInitialize()]
        public void InitializeTest()
        {
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
        }

        [TestCleanup]
        public void CleanupTest()
        {
        }

        [TestMethod]
        public async Task EdFiApiAuthentication()
        {
            using (DataFlowDbContext ctx = new DataFlowDbContext())
            {
                string authorizeUrl = DataFlow.Server.TransformLoad.Program.GetAuthorizeUrl(ctx);
                Assert.IsFalse(string.IsNullOrWhiteSpace(authorizeUrl), string.Format("{0} is Empty", nameof(authorizeUrl)));
                string accessTokenUrl = DataFlow.Server.TransformLoad.Program.GetAccessTokenUrl(ctx);
                Assert.IsFalse(string.IsNullOrWhiteSpace(accessTokenUrl), string.Format("{0} is Empty", nameof(accessTokenUrl)));
                string clientId = DataFlow.Server.TransformLoad.Program.GetApiClientId(ctx);
                Assert.IsFalse(string.IsNullOrWhiteSpace(clientId), string.Format("{0} is Empty", nameof(clientId)));
                string clientSecret = DataFlow.Server.TransformLoad.Program.GetApiClientSecret(ctx);
                Assert.IsFalse(string.IsNullOrWhiteSpace(clientSecret), string.Format("{0} is Empty", nameof(clientSecret)));
                string authCode = await DataFlow.Server.TransformLoad.Program.RetrieveAuthorizationCode(authorizeUrl, clientId: clientId);
                Assert.IsFalse(string.IsNullOrWhiteSpace(authCode), string.Format("{0} is Empty", nameof(authCode)));
                string accessToken = await DataFlow.Server.TransformLoad.Program.RetrieveAccessToken(accessTokenUrl, clientId, clientSecret, authCode);
                Assert.IsFalse(string.IsNullOrWhiteSpace(accessToken), string.Format("{0} is Empty", nameof(accessToken)));
            }
        }

        [TestMethod]
        public async Task InsertBootstrapData()
        {
            Assert.Inconclusive();
            await Task.Yield();
            using (DataFlowDbContext ctx = new DataFlowDbContext())
            {
                await DataFlow.Server.TransformLoad.Program.InsertBootrapData(ctx);
            }
        }
    }
}
