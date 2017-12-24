using Chords.Domain;
using NUnit.Framework;

namespace Chords.Tests.Domain
{
    [TestFixture]
    public sealed class ChordShapeTests
    {
        [Test]
        public void ThePreferredNameIsTheFirstOneSpecified()
        {
            var shape = new ChordShape((ChordNames) "first name" | "second name");
            
            Assert.That(shape.PreferredName, Is.EqualTo("first name"));
        }

        [Theory]
        public void RootingAShape_SetsTheRootedNote_AsTheRootNote(Note note)
        {
            var shape = new ChordShape("", Positions.Root);

            var chord = shape.RootAt(note);
            
            Assert.That(chord.RootNote, Is.EqualTo(note));
        }

        [TestCase(Note.C, new[] { Note.C, Note.G })]
        [TestCase(Note.F, new[] { Note.F, Note.C })]
        [TestCase(Note.G, new[] { Note.G, Note.D })]
        public void RootingAShape_SetsTheCorrectNotes_BasedOnTheShapePositions(Note rootNote, Note[] expectedNotes)
        {
            var shape = new ChordShape("", Positions.Root, Positions.Fifth);

            var chord = shape.RootAt(rootNote);
            
            Assert.That(chord.Notes, Is.EquivalentTo(expectedNotes));
        }
    }
}
