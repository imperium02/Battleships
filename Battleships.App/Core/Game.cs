using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;
using Battleships.App.Utils;

namespace Battleships.App.Core
{
    public class Game
    {
        private List<Ship> _ships = new List<Ship>();

        /// <summary>
        /// Starts the game loop.
        /// Leaves the loop when all ships are destroyed.
        /// </summary>
        public void StartGame()
        {
            //board and ships initialization
            ConsoleHelper.DrawBoard();
            _ships = CreateShips(2,1);
            ConsoleHelper.WriteInfo("Make your shot!");
            
            //game loop
            bool allDestroyed = false;
            while (!allDestroyed)
            {
                MakeShot();

                if (_ships.All(s => s.IsDestroyed())) 
                    allDestroyed = true;
            }
            
            //user won
            ConsoleHelper.ShowYouWinScreen();
        }

        /// <summary>
        /// Get shot coordinates from user and check if it was a hit.
        /// </summary>
        private void MakeShot()
        {
            //read user input and validate
            var shot = Console.ReadLine();
            if (!shot.IsProperShot())
            {
                ConsoleHelper.WriteInfo("Enter proper coordinates!");
                return;
            }
            
            //get coordinates into int
            int column = shot[0] - 'A';
            int row = (int) char.GetNumericValue(shot[1]);
            
            //check if any of the ships were hit
            if (_ships.Any(s => s.IsHit(column, row)))
            {
                var ship = _ships.First(s => s.HasPosition(column, row));
                ConsoleHelper.WriteChar('X', column, row);
                ConsoleHelper.WriteInfo(ship.IsDestroyed()
                    ? $"Good shot at {shot}! {ship.Type} destroyed!"
                    : $"Good shot at {shot}! It's a {ship.Type}!");
            }
            else
            {
                ConsoleHelper.WriteChar('O', column, row);
                ConsoleHelper.WriteInfo($"Miss at {shot}! Make another shot!");
            }
        }
        
        /// <summary>
        /// Create list of ship entities
        /// </summary>
        /// <param name="destroyers">Number of destroyers</param>
        /// <param name="battleships">Number of battleships</param>
        private List<Ship> CreateShips(int destroyers, int battleships)
        {
            var createdShips = new List<Ship>();
            bool allProper = false;
            while (!allProper)
            {
                _ships.Clear();
                
                //create ship entities
                for (int i = 0; i < destroyers; i++)
                {
                    createdShips.Add(new Ship(4));
                }
                for (int i = 0; i < battleships; i++)
                {
                    createdShips.Add(new Ship(5));
                }

                //get coordinates of all ships and check if they are unique
                var shipPositions = createdShips.SelectMany(s => s.Positions);
                if (shipPositions.Distinct().Count() != shipPositions.Count())
                {
                    continue;
                }

                allProper = true;
            }

            return createdShips;
        }
    }
}