using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Battleships.App
{
    class Ship
    {
        public List<Position> Positions { get; private set; }
        public string Name { get; set; }

        public Ship(int shipLength)
        {
            bool insideBoard = false;
            while (!insideBoard)
            {
                Positions = new List<Position>();
                var random = new Random();
                var rotation = (Rotation) random.Next(0, 2);
                var startRow = random.Next(0, 10);
                var startColumn = random.Next(0, 10);
                int endRow = startRow, endColumn = startColumn;
                Positions.Add(new Position(startColumn, startRow));
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

                if (endColumn > 9 || endRow > 9) continue;

                insideBoard = true;
            }

            Name = shipLength switch
            {
                4 => "Cruiser",
                5 => "Battleship",
                _ => "Not Defined"
            };
        }

        public bool IsHit(int col, int row)
        {
            var position = Positions.FirstOrDefault(p => p.Column == col && p.Row == row);
            if (position is null) return false;
            position.Taken = true;
            return true;
        }

        public bool HasPosition(int col, int row)
        {
            return Positions.Any(p => p.Column == col && p.Row == row);
        }

        public bool IsDestroyed()
        {
            return Positions.All(p => p.Taken);
        }
    }
}