namespace Chords
{
    public sealed class Chord
    {
        public ChordName Name { get; }
        public Note[] Notes { get; }

        public Chord(ChordName name, params Note[] notes)
        {
            Name = name;
            Notes = notes;
        }
    }
}
