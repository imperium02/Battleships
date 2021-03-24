using System;

namespace Battleships.App.Models
{
    public class Position : IEquatable<Position>
    {
        public int Column { get; set; }
        public char ColumnCharacter { get; set; }
        public int Row { get; set; }
        public bool Hit { get; set; }

        public Position(int column, int row)
        {
            Column = column;
            ColumnCharacter = (char) ('A' + column);
            Row = row;
            Hit = false;
        }

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Column == other.Column && Row == other.Row;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Column, Row);
        }
    }
}