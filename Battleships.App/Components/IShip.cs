using System.Collections.Generic;
using Battleships.App.Models;

namespace Battleships.App.Components
{
    public interface IShip
    {
        public string Type { get; set; }
        public List<Position> Positions { get; set; }
        
        /// <summary>
        /// Checks if ship was hit with given coordinates of the shot.
        /// </summary>
        /// <param name="col">Column coordinate of the shot</param>
        /// <param name="row">Row coordinate of the shot</param>
        /// <returns>The method return bool</returns>
        bool IsHit(int col, int row);
        
        /// <summary>
        /// Checks if ship is placed on given coordinates.
        /// </summary>
        /// <param name="col">Column coordinate</param>
        /// <param name="row">Row coordinate</param>
        /// <returns>The method returns bool</returns>
        bool HasPosition(int col, int row);
        
        /// <summary>
        /// Checks if ship is placed on given coordinates.
        /// </summary>
        /// <param name="position">Position in string</param>
        /// <returns>The method returns bool</returns>
        bool HasPosition(string position);
        
        /// <summary>
        /// Checks if ship is destroyed.
        /// </summary>
        /// <returns>The method returns bool</returns>
        bool IsDestroyed();
    }
}