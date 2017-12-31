﻿using System.Net;
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
		""url"": ""http://moodle.schoolstacks.com/export.php"",
		""parameters"": [{
				""itemid"": 0
			},
			{
				[{""mform_isexpanded_id_gradeitems"":""1""},{""checkbox_controller1"":""1""},{""mform_isexpanded_id_options"":""0""},{""id"":""3""},{""sesskey"":""4O0S9wVEf6""},{""_qf__grade_export_form"":""1""},{""itemids[8]"":""0""},{""itemids[8]"":""1""},{""itemids[9]"":""0""},{""itemids[9]"":""1""},{""itemids[10]"":""0""},{""itemids[10]"":""1""},{""itemids[11]"":""0""},{""itemids[11]"":""1""},{""itemids[12]"":""0""},{""itemids[12]"":""1""},{""itemids[13]"":""0""},{""itemids[13]"":""1""},{""itemids[14]"":""0""},{""itemids[14]"":""1""},{""itemids[15]"":""0""},{""itemids[15]"":""1""},{""itemids[16]"":""0""},{""itemids[16]"":""1""},{""itemids[17]"":""0""},{""itemids[17]"":""1""},{""itemids[18]"":""0""},{""itemids[18]"":""1""},{""itemids[7]"":""0""},{""itemids[7]"":""1""},{""export_feedback"":""0""},{""export_onlyactive"":""0""},{""export_onlyactive"":""1""},{""display[real]"":""0""},{""display[real]"":""1""},{""display[percentage]"":""0""},{""display[letter]"":""0""},{""decimals"":""2""},{""separator"":""comma""}]
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
