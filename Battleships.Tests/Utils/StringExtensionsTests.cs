using Battleships.App.Utils;
using NUnit.Framework;

namespace Battleships.Tests.Utils
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void TestProperIsProperShot()
        {
            var shot = "A5";
            Assert.IsTrue(shot.IsProperShot());
        }
        
        [Theory]
        [TestCase(null)]
        [TestCase("A643")]
        [TestCase("14")]
        [TestCase("a3")]
        [TestCase("Z7")]
        [TestCase("AB")]
        public void TestImproperIsProperShot(string? shot)
        {
            Assert.IsFalse(shot.IsProperShot());
        }
    }
}