using System.Collections.Generic;
using System.Linq;

namespace Chords
{
    public sealed class ChordLookup
    { 
        private readonly Dictionary<ChordName, Chord> chords; 
         
        public ChordLookup()
        {
            var allChords = new List<Chord>
            {
                new Chord(ChordName.AMajor,      Notes.A,      Notes.CSharp, Notes.E),
                new Chord(ChordName.BFlatMajor,  Notes.BFlat,  Notes.D,      Notes.F),
                new Chord(ChordName.BMajor,      Notes.B,      Notes.EFlat,  Notes.FSharp),
                new Chord(ChordName.CMajor,      Notes.C,      Notes.E,      Notes.G),
                new Chord(ChordName.CSharpMajor, Notes.CSharp, Notes.F,      Notes.AFlat),
                new Chord(ChordName.DMajor,      Notes.D,      Notes.FSharp, Notes.A),
                new Chord(ChordName.EFlatMajor,  Notes.EFlat,  Notes.G,      Notes.BFlat),
                new Chord(ChordName.EMajor,      Notes.E,      Notes.AFlat,  Notes.B),
                new Chord(ChordName.FMajor,      Notes.F,      Notes.A,      Notes.C),
                new Chord(ChordName.FSharpMajor, Notes.FSharp, Notes.BFlat,  Notes.CSharp),
                new Chord(ChordName.GMajor,      Notes.G,      Notes.B,      Notes.D),
                new Chord(ChordName.AFlatMajor,  Notes.AFlat,  Notes.C,      Notes.EFlat),
            };

            chords = allChords.ToDictionary(c => c.Name, c => c);
        }

        public Chord GetChord(ChordName chordName)
        {
            return chords.TryGetValue(chordName, out Chord chord)
                ? chord
                : null;
        }
    }
}
