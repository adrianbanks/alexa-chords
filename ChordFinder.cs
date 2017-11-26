using System.Linq;

namespace Chords
{
    public sealed class ChordFinder
    {
        public string GetNotesInChord(string chord)
        {
            var chordName = FindChordName(chord);

            if (chordName == null)
            {
                return $"Could not find chord {chord}";
            }
            
            var lookup = new ChordLookup();
            var notes = lookup.GetNotes(chordName.Value);

            if (notes == null)
            {
                return $"Could not find chord {chord}";
            }

            return string.Join(" ", notes.Select(n => n.ToSpoken()));
        }

        private ChordName? FindChordName(string chord)
        {
            switch (chord.ToLower())
            {
                case "b. flat":
                    return ChordName.BFlat;
                case "f":
                case "f major":
                    return ChordName.FMajor;
                case "c":
                case "c major":
                    return ChordName.CMajor;
                case "g.":
                case "g major":
                    return ChordName.GMajor;
                default: 
                    return null;
            }
        }
    }
}
