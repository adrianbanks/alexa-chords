namespace Chords
{
    public sealed class Note
    {
        private readonly string spokenName;
        private readonly string[] alternativeNames;

        public Note(string spokenName, params string[] alternativeNames)
        {
            this.spokenName = spokenName;
            this.alternativeNames = alternativeNames;
        }

        public string ToSpoken()
        {
            return spokenName;
        }
    }
}
