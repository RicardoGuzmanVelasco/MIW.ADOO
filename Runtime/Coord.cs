namespace MIW.ADOO.Runtime
{
    public class Coord
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Coord() { }
        public Coord(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public void Read(string title)
        {
            IO.Write(title + ": ¿qué casilla?");

            Row = new LimitedIntDialog("¿Fila?", Board.Dimension).Read() - 1;
            Col = new LimitedIntDialog("¿Columna?", Board.Dimension).Read() - 1;
        }

        public Direction DirectionRelativeTo(Coord other)
        {
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
        bool IsInInverseDiagonal() => Row + Col == Board.Dimension;
    }
}