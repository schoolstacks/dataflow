using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataFlow.Web.Areas.Api.Controllers
{
    [AllowAnonymous]
    public class ChromeExtensionController : ApiController
    {
        [HttpPost]
        [Route("api/register")]
        public HttpResponseMessage Register()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(@"{ ""token"": ""42287996-c177-4e58-815c-a9e390d2461f"" }", System.Text.Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPost]
        [Route("api/agents")]
        public HttpResponseMessage Agents()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(@"[{
		""agent_id"": 1,
		""action"": ""GET"",
		""url"": ""https://school-stacks.acme.instructure.com/files/906/download?download_frd=1"",
		""schedule"": [{
			""day"": 0,
			""hour"": 7,
			""minute"": 0
		}]
	},
	{
		""agent_id"": 2,
		""action"": ""POST"",
		""url"": ""http://moodle.schoolstacks.com/grade/report/history/index.php?id=2"",
		""parameters"": [{
				""itemid"": 0
			},
			{
				""datefrom[day]"": ""1""
			}
		],
		""schedule"": [{
			""day"": 0,
			""hour"": 8,
			""minute"": 0
		}, {
			""day"": 1,
			""hour"": 8,
			""minute"": 0
		}]
	}
]
", System.Text.Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
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
