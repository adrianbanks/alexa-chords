using System.Collections.Generic;

namespace Chords.Domain
{
    internal sealed class ChordName
    {
        public string Name { get; }
        public IEnumerable<Positions> Positions { get; }

        public ChordName(string name, params Positions[] positions)
        {
            Name = name;
            Positions = positions;
        }

        public Chord RootAt(Note rootNote)
        {
            var notes = new List<Note>();

            foreach (var position in Positions)
            {
                var note = NoteAdder.Add(rootNote, position);
                notes.Add(note);
            }
            
            return new Chord(rootNote, this, notes);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
