using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    public class Board
    {
        readonly Dictionary<int, HashSet<TicTacToeCoord>> coordinates;
        readonly int numPlayers;

        public Board(int numPlayers)
        {
            Debug.Assert(numPlayers > 1);

            this.numPlayers = numPlayers;
            coordinates = new Dictionary<int, HashSet<TicTacToeCoord>>
            {
                [(int) Color.X] = new HashSet<TicTacToeCoord>(),
                [(int) Color.O] = new HashSet<TicTacToeCoord>()
            };
        }

        public bool IsComplete()
        {
            var tokensCount = 0;

            for(var i = 0; i < numPlayers; i++)
                tokensCount += coordinates[i]?.Count ?? 0;

            return tokensCount == TicTacToeCoord.Dimension * numPlayers;
        }

        public bool IsTicTacToe() => IsTicTacToe(Color.O) || IsTicTacToe(Color.X);
        bool IsTicTacToe(Color color)
        {
            Debug.Assert(color != Color.None);
            
            var tokens = coordinates[(int) color].ToArray();
            if(tokens.Length != TicTacToeCoord.Dimension)
                return false;

            var direction = tokens.First().DirectionRelativeTo(tokens[1]);
            if(direction == Direction.None)
                return false;
            
            for(var i = 1; i < TicTacToeCoord.Dimension - 1; i ++)
                if(tokens[i].DirectionRelativeTo(tokens[i + 1]) != direction)
                    return false;
            
            return true;
        }

        public bool IsTileEmpty(TicTacToeCoord TicTacToeCoord)
        {
            Debug.Assert(TicTacToeCoord != null);
            
            return !IsTileFull(TicTacToeCoord, Color.X) && !IsTileFull(TicTacToeCoord, Color.O);
        }

        public bool IsTileFull(TicTacToeCoord TicTacToeCoord, Color color)
        {
            Debug.Assert(TicTacToeCoord != null);
            Debug.Assert(color != Color.None);
            
            return coordinates[(int) color].Contains(TicTacToeCoord);
        }

        public void Write() => IO.Write(ToString());

        public void Put(TicTacToeCoord TicTacToeCoord, Color color)
        {
            Debug.Assert(TicTacToeCoord != null);
            Debug.Assert(color != Color.None);
            
            coordinates[(int) color].Add(TicTacToeCoord);
        }

        public void Remove(TicTacToeCoord TicTacToeCoord)
        {
            Debug.Assert(TicTacToeCoord  != null);
            
            Put(TicTacToeCoord, Color.None);
        }
    }
}