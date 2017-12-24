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
            var words = new WordsSegragation(chordName);

            var note = MatchNote(words.Note);
            var shape = MatchShape(words.Shape);

            if (note == null || shape == null)
            {
                throw new ChordNotFoundException(chordName);
            }

            return (note.Value, shape);
        }

        private static Note? MatchNote(string noteName)
        {
            if (Enum.TryParse(noteName, true, out Note note))
            {
                return note;
            }

            return null;
        }

        private static ChordShape MatchShape(string shapeName)
        {
            return typeof(KnownChords)
                .GetFields(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Select(field => (ChordShape) field.GetValue(null))
                .FirstOrDefault(chord => chord.Names.Any(name => name == shapeName));
        }
    }
}
