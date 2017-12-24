using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace Chords.Speech
{
    internal static class SsmlResponseFactory
    {
        public static SpeechletResponse Create(string output, bool shouldEndSession)
        {
            return new SpeechletResponse
            {
                OutputSpeech = new SsmlOutputSpeech { Ssml = $"<speak>{output}</speak>" },
                ShouldEndSession = shouldEndSession
            };
        }
    }
}