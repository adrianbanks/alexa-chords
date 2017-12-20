using System.Collections.Generic;

namespace Chords.Domain
{
    internal sealed class ChordNames
    {
        private readonly List<string> names = new List<string>();
        
        public static ChordNames operator |(ChordNames left, string right)
        {
            var names = new ChordNames();
            names.names.AddRange(left.names);
            names.names.Add(right);
            return names;
        }

        public static implicit operator string[](ChordNames c)
        {
            return c.names.ToArray();
        }

        public static implicit operator ChordNames(string s)
        {
            var names = new ChordNames();
            names.names.Add(s);
            return names;
        }
    }
}
