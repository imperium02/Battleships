using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Components;
using Battleships.App.Utils;

namespace Battleships.App.Core
{
    public class Game
    {
        private readonly int _size;
        public List<IShip> Ships { get; set; }

        public Game(int size)
        {
            _size = size;
            
            //board initialization
            ConsoleHelper.DrawBoard(_size);
            ConsoleHelper.WriteInfo("Make your shot!", size);
            
            Ships = new List<IShip>();
        }

        /// <summary>
        /// Get shot coordinates from user and check if it was a hit.
        /// </summary>
        public bool MakeShot(string? userShot)
        {
            //read user input and validate
            if (!userShot.IsProperShot(_size))
            {
                ConsoleHelper.WriteInfo("Enter proper coordinates!", _size);
                return false;
            }
            
            //get coordinates into int
            int column = userShot[0] - 'A';
            int row = (int) char.GetNumericValue(userShot[1]);
            if(_size > 10 && userShot.Length == 3)
                row = row * 10 + (int) char.GetNumericValue(userShot[2]);
            
            //check if any of the ships were hit
            if (Ships.Any(s => s.IsHit(column, row)))
            {
                var ship = Ships.First(s => s.HasPosition(column, row));
                ConsoleHelper.WriteChar('X', column, row);
                ConsoleHelper.WriteInfo(ship.IsDestroyed()
                    ? $"Good shot at {userShot}! {ship.Type} destroyed!"
                    : $"Good shot at {userShot}! It's a {ship.Type}!",
                    _size);
                return true;
            }
            else
            {
                ConsoleHelper.WriteChar('O', column, row);
                ConsoleHelper.WriteInfo($"Miss at {userShot}! Make another shot!", _size);
                return false;
            }
        }
        
       
    }
}