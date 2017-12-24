using System;
using System.Diagnostics;
using AlexaSkillsKit.Slu;
using AlexaSkillsKit.Speechlet;
using Chords.Speech;

namespace Chords
{
    public sealed class ChordSpeechlet : Speechlet
    {
        public override SpeechletResponse OnLaunch(LaunchRequest launchRequest, Session session)
        {
            Trace.WriteLine($"OnLaunch called for session {session.SessionId}");
            return PlainTextResponseFactory.Create("Say a chord name", false);
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
                    return SsmlResponseFactory.Create("<say-as interpret-as='interjection'>okey dokey.</say-as>", true);
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
                return PlainTextResponseFactory.Create("Didn't recognise that chord", false);
            }
            
            try
            {
                return ProcessChord(chordName.Value);
            }
            catch (ChordNotFoundException exception)
            {
                var chord = string.Join(" ", exception.Words);
                return PlainTextResponseFactory.Create($"Didn't recognise chord {chord}", false);
            }
        }
        
        private static SpeechletResponse ProcessChord(string chordName)
        {
            var chord = new ChordFinder().GetChord(chordName);

            Trace.WriteLine($"Notes are : {string.Join(", ", chord.Notes)}");

            var ssml = $"Notes in {chord.Name} <break strength='medium'/> are <break strength='medium'/> {chord.ToNotesSsml()}";
            return SsmlResponseFactory.Create(ssml, false);
        }

        public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
        {
            Trace.WriteLine($"OnSessionEnded called for session {session.SessionId}");
        }
    }
}
