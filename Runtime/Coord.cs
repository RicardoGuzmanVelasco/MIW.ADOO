namespace MIW.ADOO.Runtime
{
    public class Coord
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public void Read(string title)
        {
            IO.Write(title);

            Row = new LimitedIntDialog("¿Fila?", 3).Read() - 1;
            Col = new LimitedIntDialog("¿Columna?", 3).Read() - 1;
        }
    }
}