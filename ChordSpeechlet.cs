using System.Diagnostics;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace Chords
{
    public class ChordSpeechlet : Speechlet
    {
        public override SpeechletResponse OnLaunch(LaunchRequest launchRequest, Session session)
        {
            Trace.WriteLine($"OnLaunch called for session {session.SessionId}");
            return BuildSpeechletResponse("Welcome", "Say a chord name", false);
        }

        public override void OnSessionStarted(SessionStartedRequest sessionStartedRequest, Session session)
        {
            Trace.WriteLine($"OnSessionStarted called for session {session.SessionId}");
        }

        public override SpeechletResponse OnIntent(IntentRequest request, Session session)
        {
            Trace.WriteLine($"OnIntent called for session {session.SessionId}");

            var intent = request.Intent;
            var intentName = intent?.Name;

            Trace.WriteLine($"Intent name: {intentName}");
            
            if ("ChordIntent".Equals(intentName))
            {
                var chord = intent.Slots["chord"];

                Trace.WriteLine($"Chord was : {chord.Name}, {chord.Value}");
                return BuildSpeechletResponse("Chord", "You said " + chord.Value, false);
            }

            Trace.WriteLine("About to fail");
            throw new SpeechletException("Invalid Intent");
        }

        public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
        {
            Trace.WriteLine($"OnSessionEnded called for session {session.SessionId}");
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
