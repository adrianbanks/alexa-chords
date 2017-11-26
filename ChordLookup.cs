using System.Collections.Generic;

namespace Chords
{
    public sealed class ChordLookup
    {
        private readonly Dictionary<ChordName, Chord> chords;
        
        public ChordLookup()
        {
            chords = new Dictionary<ChordName, Chord>
            {
                { ChordName.BFlat, new Chord(ChordName.BFlat, Notes.BFlat, Notes.D, Notes.F) },
                { ChordName.CMajor, new Chord(ChordName.CMajor, Notes.C, Notes.E, Notes.G) },
                { ChordName.FMajor, new Chord(ChordName.FMajor, Notes.F, Notes.A, Notes.C) },
                { ChordName.GMajor, new Chord(ChordName.GMajor, Notes.G, Notes.B, Notes.D) }
            };
        }

        public Note[] GetNotes(ChordName chordName)
        {
            return chords.TryGetValue(chordName, out Chord chord)
                ? chord.Notes
                : null;
        }
    }
}
