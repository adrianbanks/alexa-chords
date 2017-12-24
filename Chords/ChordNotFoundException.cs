using System;

namespace Chords
{
    internal sealed class ChordNotFoundException : Exception
    {
        public string ChordName { get; }

        public ChordNotFoundException(string chordName)
        {
            ChordName = chordName;
        }
    }
}
