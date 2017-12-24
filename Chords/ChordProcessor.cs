using System.Diagnostics;
using AlexaSkillsKit.Slu;
using AlexaSkillsKit.Speechlet;
using Chords.Speech;

namespace Chords
{
    internal sealed class ChordProcessor
    {
        public SpeechletResponse ProcessChord(Intent intent)
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
    }
}
