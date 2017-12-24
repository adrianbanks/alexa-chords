using System;
using AlexaSkillsKit.Speechlet;
using Chords.Speech;

namespace Chords
{
    public sealed class ChordSpeechlet : Speechlet
    {
        private readonly Logger logger;
        
        public ChordSpeechlet()
        {
            logger = new Logger();
        }

        public override SpeechletResponse OnLaunch(LaunchRequest launchRequest, Session session)
        {
            logger.Log($"OnLaunch called for session {session.SessionId}");
            return PlainTextResponseFactory.Create("Say a chord name", false);
        }

        public override void OnSessionStarted(SessionStartedRequest sessionStartedRequest, Session session)
        {
            logger.Log($"OnSessionStarted called for session {session.SessionId}");
        }

        public override SpeechletResponse OnIntent(IntentRequest request, Session session)
        {
            logger.Log($"OnIntent called for session {session.SessionId}");

            try
            {
                var intent = request.Intent;
                var intentName = intent?.Name;

                logger.Log($"Intent name: {intentName}");
            
                if ("ChordIntent".Equals(intentName))
                {
                    var chordProcessor = new ChordProcessor(logger);
                    return chordProcessor.ProcessChord(intent);
                }

                if ("AMAZON.CancelIntent".Equals(intentName) || "AMAZON.StopIntent".Equals(intentName))
                {
                    return SsmlResponseFactory.Create("<say-as interpret-as='interjection'>okey dokey.</say-as>", true);
                }
            }
            catch (Exception e)
            {
                logger.Log($"About to fail with error {e}");
                throw;
            }
            
            logger.Log("About to fail");
            throw new SpeechletException("Invalid Intent");
        }

        public override void OnSessionEnded(SessionEndedRequest sessionEndedRequest, Session session)
        {
            logger.Log($"OnSessionEnded called for session {session.SessionId}");
        }
    }
}
