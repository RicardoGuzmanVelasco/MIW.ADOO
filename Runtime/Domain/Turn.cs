using System.Diagnostics;
using System.Linq;

namespace MIW.ADOO.Runtime
{
    public class Turn
    {
        int value;
        readonly Player[] players;

        public Turn(Player[] players)
        {
            Debug.Assert(players != null);
            Debug.Assert(players.Any());
            Debug.Assert(players.All(p => p != null));

            this.players = players;
        }

        public Player Current() => players[value];
        public Player Next() => players[NextIndex()];
        public void Change() => value = NextIndex();

        public int NextIndex() => (value + 1) % players.Length;

    }
}