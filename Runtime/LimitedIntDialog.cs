namespace MIW.ADOO.Runtime
{
    public class LimitedIntDialog
    {
        readonly string title;
        readonly ClosedInterval limits;

        public LimitedIntDialog(string title, int max) : this(title, 1, max) { }
        public LimitedIntDialog(string title, int min, int max)
        {
            this.title = title;
            limits = new ClosedInterval(min, max);
        }

        public int Read()
        {
            int value;

            do
            {
                value = IO.ReadInt(title);
                if(!limits.Includes(value))
                    IO.Write($"El valor debe estar en el intervalo {limits}");
            }while(!limits.Includes(value));

            return value;
        }
    }
}