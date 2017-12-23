using System.Linq;
using Chords.Domain;

namespace Chords
{
    internal static class ChordSsmlExtensions
    {
        public static string ToNotesSsml(this Chord chord)
        {
            var spokenNotes = chord.Notes.Select(n => n.ToSpoken(true)).ToList();
            return string.Join("<break strength='medium'/>", spokenNotes);
        }
    }
}
