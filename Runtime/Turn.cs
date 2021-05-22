namespace MIW.ADOO.Runtime
{
    public class Turn
    {
        internal int value;

        public int Current() => value;
        public int Next() => (value + 1) % TicTacToe.PlayersCount;

        public void Change()
        {
            value++;
            value %= TicTacToe.PlayersCount;
        }
    }
}