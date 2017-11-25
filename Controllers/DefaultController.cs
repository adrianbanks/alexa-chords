using System.Net.Http;
using System.Web.Http;

namespace Chords.Controllers
{
    public class DefaultController : ApiController
    {
        public HttpResponseMessage Post()
        {
            var speechlet = new ChordSpeechlet();
            return speechlet.GetResponse(Request);
        }
    }
}
