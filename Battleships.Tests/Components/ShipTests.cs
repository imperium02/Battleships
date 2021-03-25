using System.Collections.Generic;
using Battleships.App.Components;
using Battleships.App.Models;
using NUnit.Framework;

namespace Battleships.Tests.Components
{
    [TestFixture]
    public class ShipTests
    {
        private Ship _emptyShip;
        private Ship _cruiser;
        private Ship _battleship;
        private Ship _notDefined;
        private Ship _preDefined;
        
        [SetUp]
        public void SetUp()
        {
            _emptyShip = new Ship();
            _cruiser = new Ship(4);
            _battleship = new Ship(5);
            _notDefined = new Ship(6);
            _preDefined = new Ship()
            {
                Positions =
                {
                    new Position(1, 1),
                    new Position(1, 2),
                    new Position(1, 3),
                    new Position(1, 4)
                }
            };
        }
        
        [Test]
        public void TestEmptyShip()
        {
            Assert.AreEqual(0, _emptyShip.Positions.Count);
            Assert.IsNull(_emptyShip.Type);
        }

        [Test]
        public void TestPopulatedShip()
        {
            Assert.AreEqual(4, _cruiser.Positions.Count);
            Assert.AreEqual(5, _battleship.Positions.Count);
            Assert.AreEqual(6, _notDefined.Positions.Count);

            Assert.AreEqual("Cruiser", _cruiser.Type);
            Assert.AreEqual("Battleship", _battleship.Type);
            Assert.AreEqual("Ship not defined", _notDefined.Type);
        }

        [Test]
        public void TestProperIsHit()
        {
            Assert.IsTrue(_preDefined.IsHit(1,1));
        }

        [Test]
        public void TestImproperIsHit()
        {
            Assert.IsFalse(_preDefined.IsHit(2,2));
            Assert.IsFalse(_emptyShip.IsHit(1,1));
        }

        [Test]
        public void TestProperHasPosition()
        {
            Assert.IsTrue(_preDefined.HasPosition(1,1));
            Assert.IsTrue(_preDefined.HasPosition("B1"));
        }

        [Test]
        public void TestImproperHasPosition()
        {
            Assert.IsFalse(_preDefined.HasPosition(2,2));
            Assert.IsFalse(_preDefined.HasPosition("A0"));
            Assert.IsFalse(_preDefined.HasPosition("6B"));
        }

        [Test]
        public void TestProperIsDestroyed()
        {
            var ship = new Ship() {Positions = {new Position(1,1) {Hit = true}}};
            
            Assert.IsTrue(ship.IsDestroyed());
        }

        [Test]
        public void TestImproperIsDestroyed()
        {
            Assert.IsFalse(_cruiser.IsDestroyed());
        }
    }
}