using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using MIW.ADOO.Runtime.Utils;

namespace MIW.ADOO.Runtime
{
    public class Board
    {
        readonly Dictionary<int, HashSet<Coord>> coordinates;
        readonly int numPlayers;

        public Board(int numPlayers)
        {
            Debug.Assert(numPlayers > 1);

            this.numPlayers = numPlayers;
            coordinates = new Dictionary<int, HashSet<Coord>>
            {
                [(int) Color.X] = new HashSet<Coord>(),
                [(int) Color.O] = new HashSet<Coord>()
            };
        }

        public bool IsComplete()
        {
            var tokensCount = 0;

            for(var i = 0; i < numPlayers; i++)
                tokensCount += coordinates[i]?.Count ?? 0;

            return tokensCount == Coord.Dimension * numPlayers;
        }

        public bool IsTicTacToe() => IsTicTacToe(Color.O) || IsTicTacToe(Color.X);
        bool IsTicTacToe(Color color)
        {
            Debug.Assert(color != Color.None);
            
            var tokens = coordinates[(int) color].ToArray();
            if(tokens.Length != Coord.Dimension)
                return false;

            var direction = tokens.First().DirectionRelativeTo(tokens[1]);
            if(direction == Direction.None)
                return false;
            
            for(var i = 1; i < Coord.Dimension - 1; i ++)
                if(tokens[i].DirectionRelativeTo(tokens[i + 1]) != direction)
                    return false;
            
            return true;
        }

        public bool IsTileEmpty(Coord coord)
        {
            Debug.Assert(coord != null);
            
            return !IsTileFull(coord, Color.X) && !IsTileFull(coord, Color.O);
        }

        public bool IsTileFull(Coord coord, Color color)
        {
            Debug.Assert(coord != null);
            Debug.Assert(color != Color.None);
            
            return coordinates[(int) color].Contains(coord);
        }

        public void Write() => IO.Write(ToString());

        public void Put(Coord coord, Color color)
        {
            Debug.Assert(coord != null);
            Debug.Assert(color != Color.None);
            
            coordinates[(int) color].Add(coord);
        }

        public void Remove(Coord coord)
        {
            Debug.Assert(coord  != null);
            
            Put(coord, Color.None);
        }
    }
}