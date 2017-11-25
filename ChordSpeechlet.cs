using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace Chords
{
    public class ChordSpeechlet : Speechlet
    {
        public override SpeechletResponse OnLaunch(LaunchRequest launchRequest, Session session)
        {
            return BuildSpeechletResponse("Welcome", "Say a chord name", false);
        }

        public override void OnSessionStarted(SessionStartedRequest sessionStartedRequest, Session session)
        {
        }

        public override SpeechletResponse OnIntent(IntentRequest request, Session session)
        {
            var intent = request.Intent;
            var intentName = intent?.Name;

            if ("ChordIntent".Equals(intentName))
            {
                var chord = intent.Slots["chord"];
                return BuildSpeechletResponse("Chord", "You said " + chord.Value, false);
            }

            throw new SpeechletException("Invalid Intent");
        }

        public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
        {
        }

        private SpeechletResponse BuildSpeechletResponse(string title, string output, bool shouldEndSession)
        {
            return new SpeechletResponse
            {
                Card = new SimpleCard
                {
                    Title = $"SessionSpeechlet - {title}",
                    Content = $"SessionSpeechlet - {output}"
                },
                OutputSpeech = new PlainTextOutputSpeech { Text = output },
                ShouldEndSession = shouldEndSession
            };
        }
    }
}
