using System.Collections.Generic;
using System.Linq;
using static Chords.Domain.NoteAdder;

namespace Chords.Domain
{
    internal sealed class ChordName
    {
        public string[] Names { get; }
        public IEnumerable<Positions> Positions { get; }

        public ChordName(ChordNames names, params Positions[] positions)
        {
            Names = names;
            Positions = positions;
        }

        public Chord RootAt(Note rootNote)
        {
            var notes = Positions.Select(position => Add(rootNote, position)).ToList();
            return new Chord(rootNote, this, notes);
        }

        public override string ToString()
        {
            return Names.First();
        }
    }
}
