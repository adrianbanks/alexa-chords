using Chords.Domain;
using NUnit.Framework;

namespace Chords.Tests
{
    [TestFixture]
    public sealed class ChordFinderTests
    {
        [TestCase("A major", Note.A, "major")]
        [TestCase("C minor", Note.C, "minor")]
        [TestCase("E 7th", Note.E, "7th")]
        public void CanFindAWhiteNoteChord(string chordName, Note expectedRootNote, string expectedShape)
        {
            var finder = new ChordFinder();

            var chord = finder.GetChord(chordName);
            
            Assert.That(chord.RootNote, Is.EqualTo(expectedRootNote));
            Assert.That(chord.ChordShape.Names, Contains.Item(expectedShape));
        }

        [TestCase("A flat minor", Note.AFlat, "minor")]
        [TestCase("C sharp major", Note.CSharp, "major")]
        [TestCase("E flat 7th", Note.EFlat, "7th")]
        public void CanFindABlackNoteChord(string chordName, Note expectedRootNote, string expectedShape)
        {
            var finder = new ChordFinder();

            var chord = finder.GetChord(chordName);
            
            Assert.That(chord.RootNote, Is.EqualTo(expectedRootNote));
            Assert.That(chord.ChordShape.Names, Contains.Item(expectedShape));
        }
        
        [TestCase("foo")]
        [TestCase("foo flat")]
        [TestCase("foo sharp")]
        [TestCase("foo minor")]
        [TestCase("foo major")]
        [TestCase("foo sharp major")]
        public void HandlesWhenTheNoteCannotBeParsed(string chordName)
        {
            var finder = new ChordFinder();

            Assert.Throws<ChordNotFoundException>(() => finder.GetChord(chordName));
        }

        [TestCase("C foo")]
        [TestCase("E flat foo")]
        [TestCase("F sharp foo")]
        public void HandlesWhenTheShapeCannotBeParsed(string chordName)
        {
            var finder = new ChordFinder();

            Assert.Throws<ChordNotFoundException>(() => finder.GetChord(chordName));
        }
    }
}
