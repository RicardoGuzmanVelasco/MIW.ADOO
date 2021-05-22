namespace MIW.ADOO.Runtime
{
    public class Turn
    {
        internal int value;

        public int Current() => value;
        public int Next() => (value + 1) % 2;

        public void Change()
        {
            value++;
            value %= 2;
        }
    }
}