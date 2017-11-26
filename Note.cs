namespace Chords
{
    public sealed class Note
    {
        private readonly string spokenName;

        public Note(string spokenName)
        {
            this.spokenName = spokenName;
        }

        public string ToSpoken()
        {
            return spokenName;
        }
    }
}
