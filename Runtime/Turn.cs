using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    public class Turn
    {
        internal int value;
        readonly int limit;

        public Turn(int limit)
        {
            Debug.Assert(value < limit);
            Debug.Assert(limit > 1);

            this.limit = limit;
        }

        public int Current() => value;
        public int Next() => (value + 1) % limit;

        public void Change()
        {
            value++;
            value %= limit;
        }
    }
}