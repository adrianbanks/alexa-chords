using Chords.Domain;
using NUnit.Framework;

namespace Chords.Tests.Domain
{
    [TestFixture]
    public sealed class ChordTests
    {
        [TestCase(Note.AFlat, "test chord", "A flat test chord")]
        [TestCase(Note.C, "another", "C another")]
        [TestCase(Note.F, "and another", "F and another")]
        [TestCase(Note.FSharp, "and yet another", "F sharp and yet another")]
        public void NameIsWorkedOutFromTheNoteAndTheShape(Note note, string chordName, string expectedChordName)
        {
            var chordShape = new ChordShape(chordName);
            var chord = new Chord(note, chordShape, new Note[0]);

            var name = chord.Name;
            
            Assert.That(name, Is.EqualTo(expectedChordName));
        }
    }
}
