using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;
using Battleships.App.Utils;

namespace Battleships.App.Core
{
    public class Game
    {
        public List<IShip> Ships { get; set; }

        public Game()
        {
            //board initialization
            ConsoleHelper.DrawBoard();
            ConsoleHelper.WriteInfo("Make your shot!");
            
            Ships = new List<IShip>();
        }

        /// <summary>
        /// Get shot coordinates from user and check if it was a hit.
        /// </summary>
        public bool MakeShot(string? userShot)
        {
            //read user input and validate
            if (!userShot.IsProperShot())
            {
                ConsoleHelper.WriteInfo("Enter proper coordinates!");
                return false;
            }
            
            //get coordinates into int
            int column = userShot[0] - 'A';
            int row = (int) char.GetNumericValue(userShot[1]);
            
            //check if any of the ships were hit
            if (Ships.Any(s => s.IsHit(column, row)))
            {
                var ship = Ships.First(s => s.HasPosition(column, row));
                ConsoleHelper.WriteChar('X', column, row);
                ConsoleHelper.WriteInfo(ship.IsDestroyed()
                    ? $"Good shot at {userShot}! {ship.Type} destroyed!"
                    : $"Good shot at {userShot}! It's a {ship.Type}!");
                return true;
            }
            else
            {
                ConsoleHelper.WriteChar('O', column, row);
                ConsoleHelper.WriteInfo($"Miss at {userShot}! Make another shot!");
                return false;
            }
        }
        
       
    }
}