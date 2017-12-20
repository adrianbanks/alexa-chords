namespace Chords.Domain
{
    internal static class KnownChords
    {
        public static ChordName Major = new ChordName(
            (ChordNames) "" | "major", 
            Positions.First, Positions.Third, Positions.Fifth);
        
        public static ChordName Minor = new ChordName(
            "minor", 
            Positions.First, Positions.MinorThird, Positions.Fifth);
        
        public static ChordName Major7 = new ChordName(
            (ChordNames) "major 7" | "major 7th", 
            Positions.First, Positions.Third, Positions.Fifth, Positions.Seventh);
    }
}
