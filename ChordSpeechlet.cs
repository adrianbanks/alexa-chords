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
            return BuildPlainResponse("Say a chord name", false);
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

                Trace.WriteLine($"Chord was: {chord.Value}");
                return BuildSsmlResponse("You said <break time=\"100ms\"/> " + chord.Value, false);
            }

            Trace.WriteLine("About to fail");
            throw new SpeechletException("Invalid Intent");
        }

        public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
        {
            Trace.WriteLine($"OnSessionEnded called for session {session.SessionId}");
        }

        private SpeechletResponse BuildPlainResponse(string output, bool shouldEndSession)
        {
            return new SpeechletResponse
            {
                OutputSpeech = new PlainTextOutputSpeech { Text = output },
                ShouldEndSession = shouldEndSession
            };
        }

        private SpeechletResponse BuildSsmlResponse(string output, bool shouldEndSession)
        {
            return new SpeechletResponse
            {
                OutputSpeech = new SsmlOutputSpeech { Ssml = output },
                ShouldEndSession = shouldEndSession
            };
        }
    }
}
