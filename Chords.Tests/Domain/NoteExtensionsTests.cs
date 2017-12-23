using Chords.Domain;
using NUnit.Framework;

namespace Chords.Tests.Domain
{
    [TestFixture]
    public sealed class NoteExtensionsTests
    {
        [TestCase(Note.AFlat, "A flat")]
        [TestCase(Note.A, "A")]
        [TestCase(Note.ASharp, "B flat")]
        [TestCase(Note.BFlat, "B flat")]
        [TestCase(Note.B, "B")]
        [TestCase(Note.C, "C")]
        [TestCase(Note.CSharp, "C sharp")]
        [TestCase(Note.DFlat, "C sharp")]
        [TestCase(Note.D, "D")]
        [TestCase(Note.DSharp, "E flat")]
        [TestCase(Note.EFlat, "E flat")]
        [TestCase(Note.E, "E")]
        [TestCase(Note.F, "F")]
        [TestCase(Note.FSharp, "F sharp")]
        [TestCase(Note.GFlat, "F sharp")]
        [TestCase(Note.G, "G")]
        [TestCase(Note.GSharp, "A flat")]
        public void PreferredNameIsUsed(Note note, string expected)
        {
            var spoken = note.ToSpoken();
            Assert.That(expected, Is.EqualTo(spoken));
        }
    }
}
