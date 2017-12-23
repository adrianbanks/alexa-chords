namespace Chords.Domain
{
    internal static class KnownChords
    {
        public static ChordShape Major = new ChordShape(
            (ChordNames) "" | "major", 
            Positions.Root, Positions.Third, Positions.Fifth);

        public static ChordShape Seventh = new ChordShape(
            (ChordNames) "7" | "7th", 
            Positions.Root, Positions.Third, Positions.Fifth, Positions.MinorSeventh);
        
        public static ChordShape Major7 = new ChordShape(
            (ChordNames) "major 7" | "major 7th", 
            Positions.Root, Positions.Third, Positions.Fifth, Positions.MajorSeventh);
        
        public static ChordShape Minor = new ChordShape(
            "minor", 
            Positions.Root, Positions.MinorThird, Positions.Fifth);

        public static ChordShape Minor7 = new ChordShape(
            (ChordNames) "minor 7" | "minor 7th", 
            Positions.Root, Positions.MinorThird, Positions.Fifth, Positions.MinorSeventh);
    }
}
 