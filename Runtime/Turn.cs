namespace MIW.ADOO.Runtime
{
    public class Turn
    {
        internal int value;

        public int Current()
        {
            var current = value;

            value++;
            value %= 2;

            return current;
        }

        public int Next() => (value + 1) % 2;
    }
}