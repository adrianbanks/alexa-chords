namespace Chords.Domain
{
    internal static class ChordNames
    {
        public static ChordName Major = new ChordName("major", Positions.First, Positions.Third, Positions.Fifth);
        public static ChordName Minor = new ChordName("minor", Positions.First, Positions.MinorThird, Positions.Fifth);
        public static ChordName Major7 = new ChordName("major 7", Positions.First, Positions.Third, Positions.Fifth, Positions.Seventh);
    }
}
