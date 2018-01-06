using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Chords.Domain;
using Chords.Speech;

namespace Chords.Controllers
{
    public sealed class DefaultController : ApiController
    {
        public ChordModel Get(string chord = "", bool includeSsml = false)
        {
            if (string.IsNullOrEmpty(chord))
            {
                throw new Exception(Messages.GenericNotRecognisedMessage);
            }
            
            try
            {
                var foundChord = new ChordFinder().GetChord(chord);
                var notes = includeSsml ? foundChord.ToNotesSsml() : string.Join(", ", foundChord.Notes.Select(n => n.ToSpoken()));
                return new ChordModel(foundChord.Name, notes);
            }
            catch (ChordNotFoundException exception)
            {
                throw new Exception(string.Format(Messages.SpecificNotRecognisedFormatMessage, exception.ChordName));
            }
        }
        
        public HttpResponseMessage Post()
        {
            var speechlet = new ChordSpeechlet();
            return speechlet.GetResponse(Request);
        }
    }
}
