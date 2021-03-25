using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;
using NUnit.Framework;

namespace Battleships.Tests.Components
{
    [TestFixture]
    public class ShipCreatorTests
    {
        private List<Ship> _ships;
        [SetUp]
        public void SetUp()
        {
            _ships = ShipCreator.CreateShips(2, 1);
        }
        
        [Test]
        public void TestProperShipCountCreateShips()
        {
            Assert.True(_ships.Count == 3);
        }

        [Test]
        public void TestProperPositionCountCreateShips()
        {
            var shipPositions = _ships.SelectMany(s => s.Positions).ToList();
            var distinctPositions = shipPositions.Distinct().Count();
            
            Assert.AreEqual(distinctPositions, shipPositions.Count);
        }
    }
}