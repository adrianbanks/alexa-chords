using System;
using System.Linq;
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

                if (foundChord == null)
                {
                    return null;
                }

                var chordNote = foundChord.RootNote.ToSpoken();
                var name = $"{chordNote} {foundChord.ChordShape}";
                var notes = string.Join(", ", foundChord.Notes.Select(n => n.ToSpoken()));
                return new ChordModel(name, notes);
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
