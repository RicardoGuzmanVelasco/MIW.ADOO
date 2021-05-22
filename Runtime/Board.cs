using System.Collections.Generic;
using System.Linq;

namespace MIW.ADOO.Runtime
{
    public class Board
    {
        public const int Dimension = 3;
        readonly Dictionary<int, HashSet<Coord>> coordinates;

        public Board()
        {
            coordinates = new Dictionary<int, HashSet<Coord>>
            {
                [(int) Color.X] = new HashSet<Coord>(),
                [(int) Color.O] = new HashSet<Coord>()
            };
        }

        public bool IsComplete()
        {
            var tokensCount = 0;

            for(var i = 0; i < TicTacToe.PlayersCount; i++)
                tokensCount += coordinates[i]?.Count ?? 0;

            return tokensCount == Dimension * TicTacToe.PlayersCount;
        }

        public bool IsTicTacToe() => IsTicTacToe(Color.O) || IsTicTacToe(Color.X);
        bool IsTicTacToe(Color color)
        {
            var tokens = coordinates[(int) color].ToArray();
            if(tokens.Length != Dimension)
                return false;

            var direction = tokens.First().DirectionRelativeTo(tokens[1]);
            if(direction == Direction.None)
                return false;
            
            for(var i = 1; i < Dimension - 1; i ++)
                if(tokens[i].DirectionRelativeTo(tokens[i + 1]) != direction)
                    return false;
            
            return true;
        }

        public bool IsTileEmpty(Coord coord) => !IsTileFull(coord, Color.X) && !IsTileFull(coord, Color.O);
        public bool IsTileFull(Coord coord, Color color) => coordinates[(int) color].Contains(coord);

        public void Write() => IO.Write(ToString());

        public void Put(Coord coord, Color color) => coordinates[(int)color].Add(coord);
        public void Remove(Coord coord) => Put(coord, Color.None);
    }
}