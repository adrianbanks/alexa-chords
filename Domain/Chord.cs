using System.Collections.Generic;

namespace Chords.Domain
{
    internal sealed class Chord
    {
        public string Name { get; }
        public IEnumerable<Note> Notes { get; }
        
        internal Chord(Note rootNote, ChordName chordName, IEnumerable<Note> notes)
        {
            Name = $"{rootNote} {chordName}";
            Notes = notes;
        }
    }
}
