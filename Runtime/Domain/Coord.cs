using System.Diagnostics;
using MIW.ADOO.Runtime.Utils;

namespace MIW.ADOO.Runtime
{
    public class Coord
    {
        public const int Dimension = 3;
        static readonly ClosedInterval Limits = new ClosedInterval(0, Dimension - 1);

        Utils.Coord coord;

        public Coord()
        {
            coord = new Utils.Coord();
        }
        public Coord(int row, int col)
        {
            Debug.Assert(Limits.Includes(row));
            Debug.Assert(Limits.Includes(col));

            coord = new Utils.Coord(row, col);
        }
        
        public void Read(string title)
        {
            Debug.Assert(title != null);

            IO.Write(title + ": ¿qué casilla?");

            var row = new LimitedIntDialog("¿Fila?", Dimension).Read() - 1;
            var col = new LimitedIntDialog("¿Columna?", Dimension).Read() - 1;
            coord = new Utils.Coord(row, col);
        }

        public Direction DirectionRelativeTo(Coord other)
        {
            var direction = coord.DirectionRelativeTo(other.coord);
            if(direction != Direction.None)
                return direction;
            
            if(IsInInverseDiagonal() && other.IsInInverseDiagonal())
                return Direction.InverseDiagonal;
            return direction;
        }
        
        bool IsInInverseDiagonal() => coord.Row + coord.Col == Dimension - 1;

        protected bool Equals(Coord other) => Equals(coord, other.coord);
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals((Coord) obj);
        }
        public override int GetHashCode() => coord != null ? coord.GetHashCode() : 0;
    }
}