using System;
using System.Diagnostics;
using System.Linq;
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

            try
            {
                var intent = request.Intent;
                var intentName = intent?.Name;

                Trace.WriteLine($"Intent name: {intentName}");
            
                if ("ChordIntent".Equals(intentName))
                {
                    var chord = intent.Slots["chord"];
                    Trace.WriteLine($"Chord was: {chord.Value}");

                    if (string.IsNullOrEmpty(chord.Value))
                    {
                        return BuildPlainResponse("Didn't recognise that chord", false);
                    }

                    var notes = new ChordFinder().GetNotesInChord(chord.Value);
                    
                    if (notes == null)
                    {
                        return BuildPlainResponse($"Could not find chord {chord}", false);
                    }

                    var spokenNotes = string.Join(" ", notes.Select(n => n.ToSpoken()));
                    Trace.WriteLine($"Notes are : {spokenNotes}");

                    return BuildPlainResponse(spokenNotes, false);
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
