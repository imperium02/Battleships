using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;
using Battleships.App.Models;
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
            _ships = ShipCreator.CreateShips(2, 1, 15);
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

        [Test]
        public void TestProperAreShipsIntersecting()
        {
            var ships = new List<Ship>()
            {
                new Ship(15) {Positions = {new Position(1, 1)}},
                new Ship(15) {Positions = {new Position(1, 2)}}
            };
            
            Assert.IsFalse(ShipCreator.AreShipsIntersecting(ships));
        }

        [Test]
        public void TestImproperAreShipsIntersecting()
        {
            var ships = new List<Ship>()
            {
                new Ship(15) {Positions = {new Position(1, 1)}},
                new Ship(15) {Positions = {new Position(1,1)}}
            };
            
            Assert.IsTrue(ShipCreator.AreShipsIntersecting(ships));
        }
    }
}