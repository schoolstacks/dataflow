using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataFlow.Web.Areas.Api.Controllers
{
    [AllowAnonymous]
    public class ChromeExtensionController : ApiController
    {
        [HttpGet]
        [Route("api/register")]
        public HttpResponseMessage Register()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Test"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
