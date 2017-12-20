using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;
using Chords.Domain;

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
                    var chordName = intent.Slots["chord"];
                    Trace.WriteLine($"Chord was: {chordName.Value}");

                    if (string.IsNullOrEmpty(chordName.Value))
                    {
                        return BuildPlainResponse("Didn't recognise that chord", false);
                    }

                    var chord = new ChordFinder().GetChord(chordName.Value);
                    
                    if (chord == null)
                    {
                        return BuildPlainResponse($"Could not find chord {chordName.Value}", false);
                    }

                    var spokenNotes = chord.Notes.ToSpoken();
                    Trace.WriteLine($"Notes are : {spokenNotes}");
                    return BuildSsmlResponse(chord.Notes, false);
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

        private SpeechletResponse BuildSsmlResponse(IEnumerable<Note> notes, bool shouldEndSession)
        {
            var spokenNotes = notes.Select(n => n.ToSpoken());
            string ssml = $"<speak><s>{string.Join("</s><s>", spokenNotes)}</s></speak>";

            return new SpeechletResponse
            {
                OutputSpeech = new SsmlOutputSpeech { Ssml = ssml },
                ShouldEndSession = shouldEndSession
            };
        }
    }
}
