using NUnit.Framework;

namespace Chords.Tests
{
    [TestFixture]
    public sealed class WordsSegragationTests
    {
        [TestCase("C")]
        [TestCase("F")]
        [TestCase("G")]
        public void HandlesSingleNoteChords(string chordName)
        {
            var segragation = new WordsSegragation(chordName);
            
            Assert.That(segragation.Note, Is.EqualTo(chordName).IgnoreCase);
            Assert.That(segragation.Shape, Is.Empty);
        }
        
        [TestCase("C minor", "C", "minor")]
        [TestCase("F major", "F", "major")]
        [TestCase("G seventh", "G", "seventh")]
        public void HandlesWhiteNoteChords(string chordName, string expectedNote, string expectedShape)
        {
            var segragation = new WordsSegragation(chordName);
            
            Assert.That(segragation.Note, Is.EqualTo(expectedNote).IgnoreCase);
            Assert.That(segragation.Shape, Is.EqualTo(expectedShape));
        }
        
        [TestCase("C sharp minor", "Csharp", "minor")]
        [TestCase("F sharp major", "Fsharp", "major")]
        [TestCase("G flat seventh", "Gflat", "seventh")]
        public void HandlesBlackNoteChords(string chordName, string expectedNote, string expectedShape)
        {
            var segragation = new WordsSegragation(chordName);
            
            Assert.That(segragation.Note, Is.EqualTo(expectedNote).IgnoreCase);
            Assert.That(segragation.Shape, Is.EqualTo(expectedShape));
        }

        [TestCase("C. minor", "C", "minor")]
        [TestCase("C. sharp minor", "Csharp", "minor")]
        public void SanitisesInput(string chordName, string expectedNote, string expectedShape)
        {
            var segragation = new WordsSegragation(chordName);
            
            Assert.That(segragation.Note, Is.EqualTo(expectedNote).IgnoreCase);
            Assert.That(segragation.Shape, Is.EqualTo(expectedShape));
        }
    }
}
