using Battleships.App.Models;
using NUnit.Framework;

namespace Battleships.Tests.Models
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void TestProperEqual()
        {
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 1);
            
            Assert.IsTrue(position1.Equals(position2));
            Assert.IsTrue(position1.Equals(position1));
        }

        [Test]
        public void TestImproperEqual()
        {
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 2);
            
            Assert.IsFalse(position1.Equals(position2));
            Assert.IsFalse(position1.Equals(null));
        }
    }
}