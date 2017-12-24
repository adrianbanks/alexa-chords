using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace Chords.Speech
{
    internal static class PlainTextResponseFactory
    {
        public static SpeechletResponse Create(string output, bool shouldEndSession)
        {
            return new SpeechletResponse
            {
                OutputSpeech = new PlainTextOutputSpeech { Text = output },
                ShouldEndSession = shouldEndSession
            };
        }
    }
}
