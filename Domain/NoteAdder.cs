namespace Chords.Domain
{
    internal static class NoteAdder
    {
        public static Note Add(Note rootNote, Positions position)
        {
            var value = (int) rootNote + (int) position;
            var note = (Note) (value % 12);
            return note;
        }
    }
}
