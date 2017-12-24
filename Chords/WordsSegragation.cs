using System.Linq;

namespace Chords
{
    internal sealed class WordsSegragation
    {
        public string Note { get; }
        public string Shape { get; }
        
        public WordsSegragation(string chordName)
        {
            var sanitisedChordName = chordName.Replace(".", string.Empty).ToLower();
            var words = sanitisedChordName.Split(' ');

            if (words.Length < 2 || (words[1] != "flat" && words[1] != "sharp"))
            {
                Note = words[0];
                Shape = string.Join(" ", words.Skip(1).ToArray());
            }
            else
            {
                Note = words[0] + words[1];
                Shape = string.Join(" ", words.Skip(2).ToArray());
            }
        }
    }
}
