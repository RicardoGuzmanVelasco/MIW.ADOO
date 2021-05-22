using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    public class TicTacToeCoord : Coord
    {
        public const int Dimension = 3;
        static readonly ClosedInterval Limits = new ClosedInterval(0, Dimension - 1);

        public TicTacToeCoord() : base() { }
        public TicTacToeCoord(int row, int col) : base(row, col)
        {
            Debug.Assert(Limits.Includes(row));
            Debug.Assert(Limits.Includes(col));
        }
        
        public void Read(string title)
        {
            Debug.Assert(title != null);

            IO.Write(title + ": ¿qué casilla?");

            Row = new LimitedIntDialog("¿Fila?", Dimension).Read() - 1;
            Col = new LimitedIntDialog("¿Columna?", Dimension).Read() - 1;
        }

        public Direction DirectionRelativeTo(TicTacToeCoord other)
        {
            var direction = base.DirectionRelativeTo(other);
            if(direction != Direction.None)
                return direction;
            
            if(IsInInverseDiagonal() && other.IsInInverseDiagonal())
                return Direction.InverseDiagonal;
            return direction;
        }
        
        bool IsInInverseDiagonal() => Row + Col == Dimension;

    }
}