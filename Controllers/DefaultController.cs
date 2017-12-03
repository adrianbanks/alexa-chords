using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Chords.Controllers
{
    public class DefaultController : ApiController
    {
        public string[] Get(string chord = "")
        {
            var notes = new ChordFinder().GetNotesInChord(chord);

            if (notes == null)
            {
                return new string[0];
            }
            
            return notes.Select(n => n.ToSpoken()).ToArray();
        }
        
        public HttpResponseMessage Post()
        {
            var speechlet = new ChordSpeechlet();
            return speechlet.GetResponse(Request);
        }
    }
}
