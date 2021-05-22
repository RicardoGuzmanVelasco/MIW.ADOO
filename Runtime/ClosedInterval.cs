using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    public class ClosedInterval
    {
        readonly int min;
        readonly int max;

        public ClosedInterval(int min, int max)
        {
            Debug.Assert(min < max);

            this.min = min;
            this.max = max;
        }

        public bool Includes(int value) => min <= value && value <= max;

        public override string ToString() => $"[{min},{max}]";
    }
}