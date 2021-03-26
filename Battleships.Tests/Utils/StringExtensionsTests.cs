using Battleships.App.Utils;
using NUnit.Framework;

namespace Battleships.Tests.Utils
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Theory]
        [TestCase("A5")]
        [TestCase("A13")]
        public void TestProperIsProperShot(string? shot)
        {
            Assert.IsTrue(shot.IsProperShot(15));
        }
        
        [Theory]
        [TestCase(null)]
        [TestCase("A643")]
        [TestCase("14")]
        [TestCase("a3")]
        [TestCase("Z7")]
        [TestCase("AB")]
        [TestCase("A1O")]
        [TestCase("A")]
        [TestCase("")]
        [TestCase("A0")]
        public void TestImproperIsProperShot(string? shot)
        {
            Assert.IsFalse(shot.IsProperShot(15));
        }

        [Theory]
        [TestCase("9")]
        [TestCase("15")]
        public void TestProperIsProperSize(string? size)
        {
            Assert.IsTrue(size.IsProperSize());
        }

        [Theory]
        [TestCase("0")]
        [TestCase(null)]
        [TestCase("120")]
        [TestCase("27")]
        [TestCase("01")]
        [TestCase("avef")]
        [TestCase("")]
        public void TestImproperIsProperSize(string? size)
        {
            Assert.IsFalse(size.IsProperSize());
        }

        [Test]
        public void TestProperIsProperShipsNumber()
        {
            Assert.IsTrue("3".IsProperShipsNumber());
        }

        [Theory]
        [TestCase(null)]
        [TestCase("12")]
        [TestCase("00")]
        [TestCase("")]
        [TestCase("a")]
        public void TestImproperIsProperShipsNumber(string number)
        {
            Assert.IsFalse(number.IsProperShipsNumber());
        }
    }
}