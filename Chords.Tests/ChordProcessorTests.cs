using System;
using System.Text.RegularExpressions;
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

        [Test]
        public void OutputIsSsml_WhenTheChordIsRecognised()
        {
            var processor = new ChordProcessor(new Logger(), new ChordFinder());

            var response = processor.ProcessChord("C sharp major");

            Assert.That(response.OutputSpeech, Is.TypeOf<SsmlOutputSpeech>());
        }

        [Test]
        public void OutputContainsTheNoteName_WhenTheChordIsRecognised()
        {
            var processor = new ChordProcessor(new Logger(), new ChordFinder());

            var response = processor.ProcessChord("C sharp minor");

            var output = (SsmlOutputSpeech) response.OutputSpeech;
            Assert.That(output.Ssml, Does.Contain("C sharp minor"));
        }

        [Test]
        public void OutputContainsTheChordNotesName_WhenTheChordIsRecognised()
        {
            var processor = new ChordProcessor(new Logger(), new ChordFinder());

            var response = processor.ProcessChord("C sharp major");

            AssertSsmlContentContainsText(response, "C sharp");
            AssertSsmlContentContainsText(response, "F");
            AssertSsmlContentContainsText(response, "A flat");
        }

        private void AssertIsPlainTextResponse(SpeechletResponse response, string expectedText)
        {
            Assert.That(response.OutputSpeech, Is.TypeOf<PlainTextOutputSpeech>());
            
            var output = (PlainTextOutputSpeech) response.OutputSpeech;
            Assert.That(output.Text, Is.EqualTo(expectedText));
        }

        private void AssertSsmlContentContainsText(SpeechletResponse response, string expectedText)
        {
            Assert.That(response.OutputSpeech, Is.TypeOf<SsmlOutputSpeech>());

            var output = (SsmlOutputSpeech) response.OutputSpeech;
            var outputText = StripXmlTags(output.Ssml);
            Assert.That(outputText, Does.Contain(expectedText));

            string StripXmlTags(string input)
            {
                return Regex.Replace(input, "<.*?>", string.Empty);
            }
        }
    }
}
