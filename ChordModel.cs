namespace Chords
{
    public sealed class ChordModel
    {
        public string Name { get; }
        public string Notes { get; }

        public ChordModel(string name, string notes)
        {
            Name = name;
            Notes = notes;
        }
    }
}