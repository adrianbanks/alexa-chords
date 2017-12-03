namespace Chords
{
    public sealed class ChordFinder
    {
        public Note[] GetNotesInChord(string chord)
        {
            var chordName = FindChordName(chord);
            return chordName == null ? null : new ChordLookup().GetNotes(chordName.Value);
        }

        private ChordName? FindChordName(string chord)
        {
            switch (chord.ToLower())
            {
                case "a":
                case "a. major":
                    return ChordName.AMajor;
                case "a sharp":
                case "a sharp major":
                case "b. flat":
                case "b. flat major":
                    return ChordName.BFlatMajor;
                case "b":
                case "b. major":
                    return ChordName.BMajor;
                case "c":
                case "c major":
                    return ChordName.CMajor;
                case "c sharp":
                case "c sharp major":
                case "d flat":
                case "d flat major":
                    return ChordName.CSharpMajor;
                case "d":
                case "d major":
                    return ChordName.DMajor;
                case "d sharp":
                case "d sharp major":
                case "e flat":
                case "e flat major":
                    return ChordName.EFlatMajor;
                case "e":
                case "e major":
                    return ChordName.EMajor;
                case "f":
                case "f major":
                    return ChordName.FMajor;
                case "f sharp":
                case "f sharp major":
                case "g flat":
                case "g flat major":
                    return ChordName.FSharpMajor;
                case "g.":
                case "g major":
                    return ChordName.GMajor;
                case "g sharp":
                case "g sharp major":
                case "a flat":
                case "a flat major":
                    return ChordName.AFlatMajor;
                default: 
                    return null;
            }
        }
    }
}
