using System.Net.Http;
using System.Web.Http;

namespace Chords.Controllers
{
    public sealed class DefaultController : ApiController
    {
        public Chord Get(string chord = "")
        {
            return new ChordFinder().GetChord(chord);
        }
        
        public HttpResponseMessage Post()
        {
            var speechlet = new ChordSpeechlet();
            return speechlet.GetResponse(Request);
        }
    }
}
