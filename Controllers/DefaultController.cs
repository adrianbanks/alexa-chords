using System.Net.Http;
using System.Web.Http;

namespace Chords.Controllers
{
    public class DefaultController : ApiController
    {
        public string Get(string chord = "")
        {
            return new ChordFinder().GetNotesInChord(chord);
        }
        
        public HttpResponseMessage Post()
        {
            var speechlet = new ChordSpeechlet();
            return speechlet.GetResponse(Request);
        }
    }
}
