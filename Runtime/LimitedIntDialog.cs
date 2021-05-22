namespace MIW.ADOO.Runtime
{
    public class LimitedIntDialog
    {
        string title;

        int min, max;

        public LimitedIntDialog(string title, int max) : this(title, 1, max) { }
        public LimitedIntDialog(string title, int min, int max)
        {
            this.title = title;
            this.min = min;
            this.max = max;
        }

        public int Read()
        {
            int value;
            bool ok;

            do
            {
                value = IO.ReadInt(title);
                ok = min <= value && value <= max;
                if(!ok)
                    IO.Write($"El valor debe estar en el intervalo [{min},{max}]");
            }while(!ok);

            return value;
        }
    }
}