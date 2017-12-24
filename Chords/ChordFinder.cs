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
            (Note note, ChordShape shape) = Match(spokenChordName);
            return shape.RootAt(note);
        }

        private static (Note note, ChordShape shape) Match(string chordName)
        {
            var sanitisedChordName = chordName.Replace(".", string.Empty).ToLower();
            var words = sanitisedChordName.Split(' ');

            (Note note, string[] shapeWords) = MatchNote(chordName, words);
            var shape = MatchShape(chordName, shapeWords);

            return (note, shape);
        }

        private static (Note note, string[] shapeWords) MatchNote(string chordName, string[] words)
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

            throw new ChordNotFoundException(chordName);
        }

        private static ChordShape MatchShape(string chordName, string[] chordWords)
        {
            var shapeName = string.Join(" ", chordWords);

            var shape = typeof(KnownChords)
                .GetFields(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Select(field => (ChordShape) field.GetValue(null))
                .FirstOrDefault(chord => chord.Names.Any(name => name == shapeName));
            
            if (shape == null)
            {
                throw new ChordNotFoundException(chordName);
            }
            
            return shape;
        }
    }
}
