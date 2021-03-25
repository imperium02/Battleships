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
        public static List<Ship> CreateShips(int destroyers, int battleships)
        {
            var createdShips = new List<Ship>();
            bool allProper = false;
            while (!allProper)
            {
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
                    createdShips.Clear();
                    continue;
                }

                allProper = true;
            }

            return createdShips;
        }
    }
}