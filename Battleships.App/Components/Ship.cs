using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.App.Models;
using Battleships.App.Utils;

namespace Battleships.App.Components
{
    public class Ship
    {
        private readonly int _size;
        public List<Position> Positions { get; private set; }
        public string Type { get; set; }

        /// <summary>
        /// Create ship with no parameters
        /// </summary>
        public Ship(int size)
        {
            Positions = new List<Position>();
            _size = size;
        }
        
        /// <summary>
        /// Creates ship with specified length and within boundaries of the board.
        /// </summary>
        /// <param name="shipLength">The length of a ship</param>
        public Ship(int shipLength, int size)
        {
            _size = size;
            bool insideBoard = false;
            while (!insideBoard)
            {
                //get random starting coordinates and rotation
                Positions = new List<Position>();
                var random = new Random();
                var rotation = (Rotation) random.Next(0, 2);
                var startRow = random.Next(0, _size);
                var startColumn = random.Next(0, _size);
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
                if (endColumn > _size-1 || endRow > _size-1) continue;

                insideBoard = true;
            }

            //add ship type according to it's length
            Type = shipLength switch
            {
                4 => "Cruiser",
                5 => "Battleship",
                _ => "Ship not defined"
            };
        }

        /// <summary>
        /// Checks if ship was hit with given coordinates of the shot.
        /// </summary>
        /// <param name="col">Column coordinate of the shot</param>
        /// <param name="row">Row coordinate of the shot</param>
        /// <returns>The method return bool</returns>
        public bool IsHit(int col, int row)
        {
            var position = Positions.FirstOrDefault(p => p.Column == col && p.Row == row);
            if (position is null) return false;
            position.Hit = true;
            return true;
        }

        /// <summary>
        /// Checks if ship is placed on given coordinates.
        /// </summary>
        /// <param name="col">Column coordinate</param>
        /// <param name="row">Row coordinate</param>
        /// <returns>The method returns bool</returns>
        public bool HasPosition(int col, int row)
        {
            return Positions.Any(p => p.Column == col && p.Row == row);
        }
        
        /// <summary>
        /// Checks if ship is placed on given coordinates.
        /// </summary>
        /// <param name="position">Position in string</param>
        /// <returns>The method returns bool</returns>
        public bool HasPosition(string position)
        {
            if (!position.IsProperShot(_size)) 
                return false;
            
            return Positions.Any(p => p.ColumnCharacter == position[0] && p.Row == (int) char.GetNumericValue(position[1]));
        }

        /// <summary>
        /// Checks if ship is destroyed.
        /// </summary>
        /// <returns>The method returns bool</returns>
        public bool IsDestroyed()
        {
            return Positions.All(p => p.Hit);
        }
    }
}