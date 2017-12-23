using System.Net.Http;
using System.Web.Http;
using Chords.Domain;

namespace Chords.Controllers
{
    public sealed class DefaultController : ApiController
    {
        public ChordModel Get(string chord = "")
        {
            var foundChord = new ChordFinder().GetChord(chord);
            return foundChord != null ? new ChordModel(foundChord.Name, foundChord.Notes.ToSpoken()) : null;
        }
        
        public HttpResponseMessage Post()
        {
            var speechlet = new ChordSpeechlet();
            return speechlet.GetResponse(Request);
        }
    }
}
