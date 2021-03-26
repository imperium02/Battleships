using System.Collections.Generic;
using System.Linq;

namespace Battleships.App.Components
{
    public static class ShipCreator
    {
        /// <summary>
        /// Create list of ship entities
        /// </summary>
        /// <param name="destroyers">Number of destroyers</param>
        /// <param name="battleships">Number of battleships</param>
        public static List<IShip> CreateShips(int destroyers, int battleships, int size)
        {
            var createdShips = new List<IShip>();
            bool allProper = false;
            while (!allProper)
            {
                //create ship entities
                for (int i = 0; i < destroyers; i++)
                {
                    createdShips.Add(new Ship(4, size));
                }
                for (int i = 0; i < battleships; i++)
                {
                    createdShips.Add(new Ship(5, size));
                }

                //check if ships have intersecting positions with each other
                if (AreShipsIntersecting(createdShips))
                {
                    createdShips.Clear();
                    continue;
                }
                   

                allProper = true;
            }

            return createdShips;
        }

        /// <summary>
        /// Checks if given ships have intersecting positions with each other
        /// </summary>
        /// <param name="ships">created list of ships</param>
        /// <returns>The method returns bool</returns>
        public static bool AreShipsIntersecting(List<IShip> ships)
        {
            var shipPositions = ships.SelectMany(s => s.Positions);
            return shipPositions.Distinct().Count() != shipPositions.Count();
        }
    }
}