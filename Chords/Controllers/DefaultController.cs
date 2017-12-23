using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Chords.Domain;

namespace Chords.Controllers
{
    public sealed class DefaultController : ApiController
    {
        public ChordModel Get(string chord = "", bool includeSsml = false)
        {
            if (string.IsNullOrEmpty(chord))
            {
                throw new Exception($"Didn't recognise that chord");
            }
            
            try
            {
                var foundChord = new ChordFinder().GetChord(chord);
                var notes = includeSsml ? foundChord.ToNotesSsml() : string.Join(", ", foundChord.Notes.Select(n => n.ToSpoken()));
                return new ChordModel(foundChord.Name, notes);
            }
            catch (ChordNotFoundException exception)
            {
                throw new Exception($"Didn't recognise chord '{string.Join(" ", exception.Words)}'");
            }
        }
        
        public HttpResponseMessage Post()
        {
            var speechlet = new ChordSpeechlet();
            return speechlet.GetResponse(Request);
        }
    }
}
