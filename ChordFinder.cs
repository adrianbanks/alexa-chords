using Chords.Domain;

namespace Chords
{
    internal sealed class ChordFinder
    {
        public Chord GetChord(string chordName)
        {
            switch (chordName.ToLower())
            {
                // major
                case "a":
                case "a. major":
                    return ChordNames.Major.RootAt(Note.A);
                case "a sharp":
                case "a sharp major":
                case "b. flat":
                case "b. flat major":
                    return ChordNames.Major.RootAt(Note.BFlat);
                case "b":
                case "b. major":
                    return ChordNames.Major.RootAt(Note.B);
                case "c":
                case "c major":
                    return ChordNames.Major.RootAt(Note.C);
                case "c sharp":
                case "c sharp major":
                case "d flat":
                case "d flat major":
                    return ChordNames.Major.RootAt(Note.CSharp);
                case "d":
                case "d major":
                    return ChordNames.Major.RootAt(Note.D);
                case "d sharp":
                case "d sharp major":
                case "e flat":
                case "e flat major":
                    return ChordNames.Major.RootAt(Note.EFlat);
                case "e":
                case "e major":
                    return ChordNames.Major.RootAt(Note.E);
                case "f":
                case "f major":
                    return ChordNames.Major.RootAt(Note.F);
                case "f sharp":
                case "f sharp major":
                case "g flat":
                case "g flat major":
                    return ChordNames.Major.RootAt(Note.FSharp);
                case "g.":
                case "g major":
                    return ChordNames.Major.RootAt(Note.G);
                case "g sharp":
                case "g sharp major":
                case "a flat":
                case "a flat major":
                    return ChordNames.Major.RootAt(Note.AFlat);
                    
                // minor
                case "a minor":
                    return ChordNames.Minor.RootAt(Note.A);
                case "a sharp minor":
                case "b. flat minor":
                    return ChordNames.Minor.RootAt(Note.BFlat);
                case "b. minor":
                    return ChordNames.Minor.RootAt(Note.B);
                case "c minor":
                    return ChordNames.Minor.RootAt(Note.C);
                case "c sharp minor":
                case "d flat minor":
                    return ChordNames.Minor.RootAt(Note.CSharp);
                case "d minor":
                    return ChordNames.Minor.RootAt(Note.D);
                case "d sharp minor":
                case "e flat minor":
                    return ChordNames.Minor.RootAt(Note.EFlat);
                case "e minor":
                    return ChordNames.Minor.RootAt(Note.E);
                case "f minor":
                    return ChordNames.Minor.RootAt(Note.F);
                case "f sharp minor":
                case "g. flat minor":
                    return ChordNames.Minor.RootAt(Note.FSharp);
                case "g. minor":
                    return ChordNames.Minor.RootAt(Note.G);
                case "g. sharp minor":
                case "a flat minor":
                    return ChordNames.Minor.RootAt(Note.AFlat);

                default: 
                    return null;
            }
        }
    }
}
