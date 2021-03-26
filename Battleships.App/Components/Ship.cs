using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Models;
using Battleships.App.Utils;

namespace Battleships.App.Components
{
    public class Ship : IShip
    {
        public List<Position> Positions { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// Create ship with no parameters
        /// </summary>
        public Ship()
        {
            Positions = new List<Position>();
        }
        
        /// <summary>
        /// Creates ship with specified length and within boundaries of the board.
        /// </summary>
        /// <param name="shipLength">The length of a ship</param>
        public Ship(int shipLength)
        {
            bool insideBoard = false;
            while (!insideBoard)
            {
                //get random starting coordinates and rotation
                Positions = new List<Position>();
                var random = new Random();
                var rotation = (Rotation) random.Next(0, 2);
                var startRow = random.Next(0, 10);
                var startColumn = random.Next(0, 10);
                int endRow = startRow, endColumn = startColumn;
                
                //add starting coordinate
                Positions.Add(new Position(startColumn, startRow));
                
                //depending on rotation increment column or row and add new coordinate
                switch (rotation)
                {
                    case Rotation.Horizontal:
                        for (int i = 1; i < shipLength; i++)
                        {
                            endColumn++;
                            Positions.Add(new Position(endColumn, startRow));
                        }

                        break;
                    case Rotation.Vertical:
                        for (int i = 1; i < shipLength; i++)
                        {
                            endRow++;
                            Positions.Add(new Position(startColumn, endRow));
                        }

                        break;
                }

                //check if created ship is placed within board boundaries
                if (endColumn > 9 || endRow > 9) continue;

                insideBoard = true;
            }

            //add ship type according to it's length
            Type = shipLength switch
            {
                4 => "Destroyer",
                5 => "Battleship",
                _ => "Ship not defined"
            };
        }
        
        public bool IsHit(int col, int row)
        {
            var position = Positions.FirstOrDefault(p => p.Column == col && p.Row == row);
            if (position is null) return false;
            position.Hit = true;
            return true;
        }
        
        public bool HasPosition(int col, int row)
        {
            return Positions.Any(p => p.Column == col && p.Row == row);
        }
        
        public bool HasPosition(string position)
        {
            if (!position.IsProperShot()) 
                return false;
            
            return Positions.Any(p => p.ColumnCharacter == position[0] && p.Row == (int) char.GetNumericValue(position[1]));
        }
        
        public bool IsDestroyed()
        {
            return Positions.All(p => p.Hit);
        }
    }
}