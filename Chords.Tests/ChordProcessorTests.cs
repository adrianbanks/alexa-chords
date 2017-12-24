using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;
using Chords.Speech;
using NUnit.Framework;

namespace Chords.Tests
{
    [TestFixture]
    public sealed class ChordProcessorTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void EmptyInputsAreHandled(string chordName)
        {
            var processor = new ChordProcessor(new Logger(), new ChordFinder());

            var response = processor.ProcessChord(chordName);
            
            AssertIsPlainTextResponse(response, Messages.GenericNotRecognisedMessage);
        }

        [TestCase("some random words")]
        [TestCase("c sharp foo")]
        public void UnrecognisedChordNamesAreHandled(string chordName)
        {
            var processor = new ChordProcessor(new Logger(), new ChordFinder());

            var response = processor.ProcessChord(chordName);

            var expectedMessage = string.Format(Messages.SpecificNotRecognisedFormatMessage, chordName);
            AssertIsPlainTextResponse(response, expectedMessage);
        }

        private void AssertIsPlainTextResponse(SpeechletResponse response, string expectedText)
        {
            Assert.That(response.OutputSpeech, Is.TypeOf<PlainTextOutputSpeech>());
            
            var output = (PlainTextOutputSpeech) response.OutputSpeech;
            Assert.That(output.Text, Is.EqualTo(expectedText));
        }
    }
}
