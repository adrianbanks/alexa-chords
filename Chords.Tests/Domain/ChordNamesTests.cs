using Chords.Domain;
using NUnit.Framework;

namespace Chords.Tests.Domain
{
    [TestFixture]
    public sealed class ChordNamesTests
    {
        [Test]
        public void CanBeCastFromAString()
        {
            ChordNames chordNames = "value";

            Assert.That(chordNames.Names, Is.EquivalentTo(new[] { "value" }));
        }
        
        [Test]
        public void CanBeOredWithAString()
        {
            var chordNames = new ChordNames() | "value 1" | "value 2";
            
            Assert.That(chordNames.Names, Is.EquivalentTo(new[] { "value 1", "value 2" }));
        }

        [Test]
        public void CanBeCastToAStringArray()
        {
            var chordNames = new ChordNames() | "value 1" | "value 2";

            string[] names = chordNames;
            
            Assert.That(names, Is.EquivalentTo(new[] { "value 1", "value 2" }));
        }
    }
}
