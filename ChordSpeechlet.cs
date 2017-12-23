using System;
using System.Diagnostics;
using AlexaSkillsKit.Slu;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;

namespace Chords
{
    public sealed class ChordSpeechlet : Speechlet
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

            try
            {
                var intent = request.Intent;
                var intentName = intent?.Name;

                Trace.WriteLine($"Intent name: {intentName}");
            
                if ("ChordIntent".Equals(intentName))
                {
                    return ProcessChord(intent);
                }

                if ("AMAZON.CancelIntent".Equals(intentName) || "AMAZON.StopIntent".Equals(intentName))
                {
                    return BuildSsmlResponse("<say-as interpret-as='interjection'>okey dokey.</say-as>", true);
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine($"About to fail with error {e}");
                throw;
            }
            
            Trace.WriteLine("About to fail");
            throw new SpeechletException("Invalid Intent");
        }

        private static SpeechletResponse ProcessChord(Intent intent)
        {
            var chordName = intent.Slots["chord"];
            Trace.WriteLine($"Chord was: {chordName.Value}");

            if (string.IsNullOrEmpty(chordName.Value))
            {
                return BuildPlainResponse("Didn't recognise that chord", false);
            }
            
            try
            {
                return ProcessChord(chordName.Value);
            }
            catch (ChordNotFoundException exception)
            {
                var chord = string.Join(" ", exception.Words);
                return BuildPlainResponse($"Didn't recognise chord {chord}", false);
            }
        }
        
        private static SpeechletResponse ProcessChord(string chordName)
        {
            var chord = new ChordFinder().GetChord(chordName);

            Trace.WriteLine($"Notes are : {string.Join(", ", chord.Notes)}");

            var ssml = $"Notes in {chord.Name} are {chord.ToNotesSsml()}";
            return BuildSsmlResponse(ssml, false);
        }

        public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
        {
            Trace.WriteLine($"OnSessionEnded called for session {session.SessionId}");
        }
        
        private static SpeechletResponse BuildPlainResponse(string output, bool shouldEndSession)
        {
            return new SpeechletResponse
            {
                OutputSpeech = new PlainTextOutputSpeech { Text = output },
                ShouldEndSession = shouldEndSession
            };
        }

        private static SpeechletResponse BuildSsmlResponse(string output, bool shouldEndSession)
        {
            return new SpeechletResponse
            {
                OutputSpeech = new SsmlOutputSpeech { Ssml = $"<speak>{output}</speak>" },
                ShouldEndSession = shouldEndSession
            };
        }
    }
}
