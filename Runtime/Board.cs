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

        public bool IsTicTacToe()
        {
            return IsTicTacToe('x') || IsTicTacToe('o');
        }

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

        public bool IsTileEmpty(int row, int column)
        {
            return tokens[row, column].Equals('_');
        }

        public bool IsTileFull(int row, int column, char color)
        {
            return tokens[row, column].Equals(color);
        }
        
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

        public void Put(int row, int column, char color)
        {
            tokens[row, column] = color;
        }

        public void Remove(int row, int column)
        {
            tokens[row, column] = '_';
        }
    }
}