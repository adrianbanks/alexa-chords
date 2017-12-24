using System;
using System.Linq;
using System.Reflection;
using Chords.Domain;

namespace Chords
{
    internal sealed class ChordFinder
    {
        public Chord GetChord(string spokenChordName)
        {
            (Note note, ChordShape chord) = Match(spokenChordName);
            return chord.RootAt(note);
        }

        private static (Note note, ChordShape chord) Match(string chordName)
        {
            var sanitisedChordName = chordName.Replace(".", string.Empty).ToLower();
            var words = sanitisedChordName.Split(' ');

            (Note note, string[] chordWords) = MatchNote(words);
            var chord = MatchChord(chordWords);

            if (chord == null)
            {
                throw new ChordNotFoundException(words);
            }

            return (note, chord);
        }

        private static (Note note, string[] chordWords) MatchNote(string[] words)
        {
            if (words.Length < 2 || (words[1] != "flat" && words[1] != "sharp"))
            {
                if (Enum.TryParse(words[0], true, out Note note))
                {
                    return (note, words.Skip(1).ToArray());
                }
            }

            if (Enum.TryParse(words[0] + words[1], true, out Note sharpFlatNote))
            {
                return (sharpFlatNote, words.Skip(2).ToArray());
            }

            throw new ChordNotFoundException(words);
        }

        private static ChordShape MatchChord(string[] chordWords)
        {
            var chordName = string.Join(" ", chordWords);

            return typeof(KnownChords)
                .GetFields(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Select(field => (ChordShape) field.GetValue(null))
                .FirstOrDefault(chord => chord.Names.Any(name => name == chordName));
        }
    }
}
