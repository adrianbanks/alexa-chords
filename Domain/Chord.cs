using System.Collections.Generic;

namespace Chords.Domain
{
    internal sealed class Chord
    {
        public string Name { get; }
        public IEnumerable<Note> Notes { get; }
        
        internal Chord(Note rootNote, ChordShape chordShape, IEnumerable<Note> notes)
        {
            Name = $"{rootNote} {chordShape}";
            Notes = notes;
        }
    }
}
