namespace Chords.Domain
{
    internal static class KnownChords
    {
        public static ChordShape Major = new ChordShape(
            (ChordNames) "" | "major", 
            Positions.Unison, Positions.MajorThird, Positions.PerfectFifth);

        public static ChordShape Seventh = new ChordShape(
            (ChordNames) "7" | "7th", 
            Positions.Unison, Positions.MajorThird, Positions.PerfectFifth, Positions.MinorSeventh);
        
        public static ChordShape Major7 = new ChordShape(
            (ChordNames) "major 7" | "major 7th", 
            Positions.Unison, Positions.MajorThird, Positions.PerfectFifth, Positions.MajorSeventh);
        
        public static ChordShape Minor = new ChordShape(
            "minor", 
            Positions.Unison, Positions.MinorThird, Positions.PerfectFifth);

        public static ChordShape Minor7 = new ChordShape(
            (ChordNames) "minor 7" | "minor 7th", 
            Positions.Unison, Positions.MinorThird, Positions.PerfectFifth, Positions.MinorSeventh);
    }
}
