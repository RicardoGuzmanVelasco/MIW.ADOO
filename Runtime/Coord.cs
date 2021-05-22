using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    public class Coord
    {
        public int Row { get; protected set; }
        public int Col { get; protected set; }

        public Coord() { }
        public Coord(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public Direction DirectionRelativeTo(Coord other)
        {
            Debug.Assert(other != null);
            
            if(Row == other.Row)
                return Direction.Horizontal;
            
            if(Col == other.Col)
                return Direction.Vertical;
            
            if(IsInDiagonal() && other.IsInDiagonal())
                return Direction.Diagonal;
            
            return Direction.None;
        }

        bool IsInDiagonal() => Row == Col;

        protected bool Equals(Coord other) => Row == other.Row && Col == other.Col;
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != GetType()) return false;
            return Equals((Coord) obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Col;
            }
        }
    }
}