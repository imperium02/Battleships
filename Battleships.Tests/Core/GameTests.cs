using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Battleships.App.Components;
using Battleships.App.Core;
using Battleships.App.Models;
using NUnit.Framework;

namespace Battleships.Tests.Core
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;
        [SetUp]
        public void SetUp()
        {
            _game = new Game() { Ships = new List<Ship>()
            {
                new Ship()
                {
                    Positions = {
                        new Position(1,1), 
                        new Position(1,2),
                        new Position(1,3), 
                        new Position(1,4)
                        
                    }, 
                    Type = "Cruiser"
                }
            }};
        }
        
        [Test]
        public void MakeGoodShotTest()
        {
            var shipPosition = _game.Ships[0].Positions.First();
            var shot = shipPosition.ColumnCharacter + shipPosition.Row.ToString();

            Assert.IsTrue(_game.MakeShot(shot));
        }
        
        [Test]
        public void MakeMissedShotTest()
        {
            var shot = "A0";
            
            Assert.IsFalse(_game.MakeShot(shot));
        }
        
        [Theory]
        [TestCase("asfas")]
        [TestCase("A34")]
        [TestCase("4353")]
        [TestCase("-@$fg")]
        [TestCase("5A")]
        public void MakeImproperShotTest(string shot)
        {
            Assert.IsFalse(_game.MakeShot(shot));
        }
    }
}