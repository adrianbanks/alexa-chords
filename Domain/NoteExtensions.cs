using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Chords.Domain
{
    internal static class NoteExtensions
    {
        public static string ToSpoken(this IEnumerable<Note> notes)
        {
            var sb = new StringBuilder();
            
            foreach (var note in notes)
            {
                sb.Append(note.ToSpoken());
                sb.Append(" ");
            }
            
            return sb.ToString().Trim();
        }
        
        public static string ToSpoken(this Note enumType)
        {
            return ToSpoken(enumType.ToString());
        }

        public static string ToSpoken(this string str)
        {
            var capitalLetterMatch = new Regex("\\B[A-Z]", RegexOptions.Compiled);
            return capitalLetterMatch.Replace(str, " $&");
        }
    }
}
