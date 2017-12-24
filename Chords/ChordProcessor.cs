using AlexaSkillsKit.Speechlet;
using Chords.Speech;

namespace Chords
{
    internal sealed class ChordProcessor
    {
        private readonly Logger logger;
        private readonly ChordFinder chordFinder;

        public ChordProcessor(Logger logger, ChordFinder chordFinder)
        {
            this.logger = logger;
            this.chordFinder = chordFinder;
        }

        public SpeechletResponse ProcessChord(string chordName)
        {
            logger.Log($"Chord was: {chordName}");

            if (string.IsNullOrWhiteSpace(chordName))
            {
                return PlainTextResponseFactory.Create(Messages.GenericNotRecognisedMessage, false);
            }
            
            try
            {
                return CreateChordResponse(chordName);
            }
            catch (ChordNotFoundException exception)
            {
                var message = string.Format(Messages.SpecificNotRecognisedFormatMessage, exception.ChordName);
                return PlainTextResponseFactory.Create(message, false);
            }
        }
        
        private SpeechletResponse CreateChordResponse(string chordName)
        {
            var chord = chordFinder.GetChord(chordName);

            logger.Log($"Notes are : {string.Join(", ", chord.Notes)}");

            var ssml = $"Notes in {chord.Name} <break strength='medium'/> are <break strength='medium'/> {chord.ToNotesSsml()}";
            return SsmlResponseFactory.Create(ssml, false);
        }
    }
}
