using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    public class TicTacToeCoord
    {
        public const int Dimension = 3;
        static readonly ClosedInterval Limits = new ClosedInterval(0, Dimension - 1);

        Coord coord;

        public TicTacToeCoord()
        {
            coord = new Coord();
        }
        public TicTacToeCoord(int row, int col)
        {
            Debug.Assert(Limits.Includes(row));
            Debug.Assert(Limits.Includes(col));

            coord = new Coord(row, col);
        }
        
        public void Read(string title)
        {
            Debug.Assert(title != null);

            IO.Write(title + ": ¿qué casilla?");

            var row = new LimitedIntDialog("¿Fila?", Dimension).Read() - 1;
            var col = new LimitedIntDialog("¿Columna?", Dimension).Read() - 1;
            coord = new Coord(row, col);
        }

        public Direction DirectionRelativeTo(TicTacToeCoord other)
        {
            var direction = coord.DirectionRelativeTo(other.coord);
            if(direction != Direction.None)
                return direction;
            
            if(IsInInverseDiagonal() && other.IsInInverseDiagonal())
                return Direction.InverseDiagonal;
            return direction;
        }
        
        bool IsInInverseDiagonal() => coord.Row + coord.Col == Dimension - 1;

        protected bool Equals(TicTacToeCoord other) => Equals(coord, other.coord);
        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals((TicTacToeCoord) obj);
        }
        public override int GetHashCode() => coord != null ? coord.GetHashCode() : 0;
    }
}