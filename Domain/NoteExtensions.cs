using System.Text.RegularExpressions;

namespace Chords.Domain
{
    internal static class NoteExtensions
    {
        public static string ToSpoken(this Note enumType, bool addSpellingNotation = false)
        {
            var capitalLetterMatch = new Regex("\\B[A-Z]", RegexOptions.Compiled);
            var spoken = capitalLetterMatch.Replace(enumType.ToString(), " $&");

            var note = spoken[0];
            var modifier = spoken.Substring(1).ToLower();

            return addSpellingNotation 
                ? $"<say-as interpret-as='character'>{note}</say-as>" + modifier 
                : note + modifier;
        }
    }
}
