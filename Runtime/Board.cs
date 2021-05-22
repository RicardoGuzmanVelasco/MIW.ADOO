using System;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public class Board
    {
        readonly char[,] tokens;

        public Board()
        {
            tokens = new char[3,3];
            for(var i = 0; i < 3; i++)
            for(var j = 0; j < 3; j++)
                tokens[i, j] = '_';
        }

        public bool IsComplete()
        {
            var tokensCount = 0;

            for(var i = 0; i < 3; i++)
            for(var j = 0; j < 3; j++)
                if(!tokens[i, j].Equals('_'))
                    tokensCount++;

            return tokensCount == 6;
        }

        public bool IsTicTacToe() => IsTicTacToe('x') || IsTicTacToe('o');
        bool IsTicTacToe(char token)
        {
            if(tokens[1, 1].Equals(token))
            {
                if(tokens[0, 0].Equals(token))
                {
                    return tokens[2, 2].Equals(token);
                }

                if(tokens[0, 2].Equals(token))
                {
                    return tokens[2, 0].Equals(token);
                }

                if(tokens[0, 1].Equals(token))
                {
                    return tokens[2, 1].Equals(token);
                }

                if(tokens[1, 0].Equals(token))
                {
                    return tokens[1, 2].Equals(token);
                }

                return false;
            }

            if(tokens[0, 0].Equals(token))
            {
                if(tokens[0, 1].Equals(token))
                {
                    return tokens[0, 2].Equals(token);
                }

                if(tokens[1, 0].Equals(token))
                {
                    return tokens[2, 0].Equals(token);
                }

                return false;
            }

            if(tokens[2, 2].Equals(token))
            {
                if(tokens[1, 2].Equals(token))
                {
                    return tokens[0, 2].Equals(token);
                }

                if(tokens[2, 1].Equals(token))
                {
                    return tokens[2, 0].Equals(token);
                }

                return false;
            }

            return false;
        }

        public bool IsTileEmpty(Coord coord) => IsTileFull(coord, '_');
        public bool IsTileFull(Coord coord, char color) => tokens[coord.Row, coord.Col].Equals(color);

        public void Write() => IO.Write(ToString());
        
        public override string ToString()
        {
            var board = "";

            for(var i = 0; i < 3; i++)
            {
                for(var j = 0; j < 3; j++)
                    board += tokens[i, j] + " ";
                board += "\n";
            }

            return board;
        }

        public void Put(Coord coord, char color) => tokens[coord.Row, coord.Col] = color;
        public void Remove(Coord coord) => Put(coord, '_');
    }
}