using System;
using System.Net.Http;
using System.Web.Http;
using Chords.Domain;

namespace Chords.Controllers
{
    public sealed class DefaultController : ApiController
    {
        public ChordModel Get(string chord = "")
        {
            try
            {
                var foundChord = new ChordFinder().GetChord(chord);
                return foundChord != null ? new ChordModel(foundChord.Name, foundChord.Notes.ToSpoken()) : null;

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
