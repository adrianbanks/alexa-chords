namespace Chords.Domain
{
    internal static class KnownChords
    {
        public static ChordShape Major = new ChordShape(
            (ChordNames) "" | "major", 
            Positions.First, Positions.Third, Positions.Fifth);

        public static ChordShape Major7 = new ChordShape(
            (ChordNames) "major 7" | "major 7th", 
            Positions.First, Positions.Third, Positions.Fifth, Positions.MinorSeventh);
        
        public static ChordShape Minor = new ChordShape(
            "minor", 
            Positions.First, Positions.MinorThird, Positions.Fifth);

        public static ChordShape Minor7 = new ChordShape(
            (ChordNames) "minor 7" | "minor 7th", 
            Positions.First, Positions.MinorThird, Positions.Fifth, Positions.MinorSeventh);
    }
}
