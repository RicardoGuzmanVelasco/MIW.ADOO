using System;
using System.Diagnostics;
using System.Linq;

namespace MIW.ADOO.Runtime
{
    public class Turn
    {
        int value;

        public Color Current() => (Color)value;
        public Color Next() => (Color)NextIndex();
        public void Change() => value = NextIndex();

        public int NextIndex() => (value + 1) % Enum.GetValues(typeof(Color)).Length;
    }
}