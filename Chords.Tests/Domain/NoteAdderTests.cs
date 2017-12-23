using Chords.Domain;
using NUnit.Framework;

namespace Chords.Tests.Domain
{
    [TestFixture]
    public sealed class NoteAdderTests
    {
        [TestCase(Positions.Root, Note.C)]
        [TestCase(Positions.Unison, Note.C)]
        [TestCase(Positions.DiminishedSecond, Note.C)]
        [TestCase(Positions.MinorSecond, Note.CSharp)]
        [TestCase(Positions.AugmentedUnison, Note.CSharp)]
        [TestCase(Positions.Second, Note.D)]
        [TestCase(Positions.MajorSecond, Note.D)]
        [TestCase(Positions.DiminishedThird, Note.D)]
        [TestCase(Positions.MinorThird, Note.EFlat)]
        [TestCase(Positions.AugmentedSecond, Note.EFlat)]
        [TestCase(Positions.Third, Note.E)]
        [TestCase(Positions.MajorThird, Note.E)]
        [TestCase(Positions.DiminishedFourth, Note.E)]
        [TestCase(Positions.Fourth, Note.F)]
        [TestCase(Positions.PerfectFourth, Note.F)]
        [TestCase(Positions.AugmentedThird, Note.F)]
        [TestCase(Positions.DiminishedFifth, Note.FSharp)]
        [TestCase(Positions.AugmentedFourth, Note.FSharp)]
        [TestCase(Positions.Fifth, Note.G)]
        [TestCase(Positions.PerfectFifth, Note.G)]
        [TestCase(Positions.DimishedSixth, Note.G)]
        [TestCase(Positions.MinorSixth, Note.AFlat)]
        [TestCase(Positions.AugmentedFifth, Note.AFlat)]
        [TestCase(Positions.Sixth, Note.A)]
        [TestCase(Positions.MajorSixth, Note.A)]
        [TestCase(Positions.DiminishedSeventh, Note.A)]
        [TestCase(Positions.MinorSeventh, Note.BFlat)]
        [TestCase(Positions.AugmentedSixth, Note.BFlat)]
        [TestCase(Positions.Seventh, Note.B)]
        [TestCase(Positions.MajorSeventh, Note.B)]
        [TestCase(Positions.DiminishedOctave, Note.B)]
        [TestCase(Positions.PerfectOctave, Note.C)]
        [TestCase(Positions.AugmentedSeventh, Note.C)]
        [TestCase(Positions.Ninth, Note.D)]
        [TestCase(Positions.Eleventh, Note.F)]
        [TestCase(Positions.Thirteenth, Note.A)]
        public void NotesCanBeAddedTogetherCorrectly(Positions position, Note expectedNote)
        {
            var result = NoteAdder.Add(Note.C, position);
            Assert.That(result, Is.EqualTo(expectedNote));
        }
    }
}
