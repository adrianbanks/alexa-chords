using System;

namespace Chords
{
    internal sealed class ChordNotFoundException : Exception
    {
        public string[] Words { get; }

        public ChordNotFoundException(string[] words)
        {
            Words = words;
        }
    }
}
