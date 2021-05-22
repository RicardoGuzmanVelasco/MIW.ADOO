using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    public class Coord
    {
        public const int Dimension = 3;
        static readonly ClosedInterval Limits = new ClosedInterval(0, Dimension - 1);

        public int Row { get; private set; }
        public int Col { get; private set; }

        public Coord() { }
        public Coord(int row, int col)
        {
            Debug.Assert(Limits.Includes(row));
            Debug.Assert(Limits.Includes(col));
            
            Row = row;
            Col = col;
        }

        public void Read(string title)
        {
            Debug.Assert(title != null);

            IO.Write(title + ": ¿qué casilla?");

            Row = new LimitedIntDialog("¿Fila?", Dimension).Read() - 1;
            Col = new LimitedIntDialog("¿Columna?", Dimension).Read() - 1;
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
            
            if(IsInInverseDiagonal() && other.IsInInverseDiagonal())
                return Direction.InverseDiagonal;
            
            return Direction.None;
        }

        bool IsInDiagonal() => Row == Col;
        bool IsInInverseDiagonal() => Row + Col == Dimension;

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