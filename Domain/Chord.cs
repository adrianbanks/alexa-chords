using System.Collections.Generic;

namespace Chords.Domain
{
    internal sealed class Chord
    {
        public Note RootNote { get; }
        public ChordShape ChordShape { get; }
        public IEnumerable<Note> Notes { get; }
        
        public string Name => $"{RootNote.ToSpoken()} {ChordShape}";

        internal Chord(Note rootNote, ChordShape chordShape, IEnumerable<Note> notes)
        {
            RootNote = rootNote;
            ChordShape = chordShape;
            Notes = notes;
        }
    }
}
