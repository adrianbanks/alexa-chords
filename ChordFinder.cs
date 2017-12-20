using System;
using System.Linq;
using System.Reflection;
using Chords.Domain;

namespace Chords
{
    internal sealed class ChordFinder
    {
        public Chord  GetChord(string spokenChordName)
        {
            (Note note, ChordName chord) = Match(spokenChordName);
            return chord.RootAt(note);
        }

        private (Note note, ChordName chord) Match(string chordName)
        {
            var sanitisedChordName = chordName.Replace(".", string.Empty).ToLower();
            var words = sanitisedChordName.Split(' ');

            (Note note, string[] chordWords) = MatchNote(words);
            var chord = MatchChord(chordWords);

            return (note, chord);
        }

        private (Note note, string[] chordWords) MatchNote(string[] words)
        {
            if (words.Length < 2 || (words[1] != "flat" && words[1] != "sharp"))
            {
                Enum.TryParse(words[0], true, out Note note);
                return (note, words.Skip(1).ToArray());
            }

            Enum.TryParse(words[0] + words[1], true, out Note sharpFlatNote);
            return (sharpFlatNote, words.Skip(2).ToArray());
        }

        private ChordName MatchChord(string[] chordWords)
        {
            var chordName = string.Join(" ", chordWords);

            return typeof(KnownChords)
                .GetFields(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Select(field => (ChordName) field.GetValue(null))
                .FirstOrDefault(chord => chord.Names.Any(name => name == chordName));
        }
    }
}
