using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        public static char[] Color = {'x', 'o'};
        
        char[,] tokens;
        int turn;

        Start start;
        Put put;
        Move move;

        public TicTacToe()
        {
            turn = 0;

            tokens = new char[3,3];

            start = new Start(tokens);
            put = new Put(tokens);
        }

        public void Play()
        {
            do
            {
                start.Write();
                if(!IsComplete())
                    put.DoPut(turn, this);
                else
                    move.DoMove(turn, this);
                turn = (turn + 1) % 2;
            } while(!IsTicTacToe());

            start.Write();
            Win(turn);
        }

        void Win(int turn)
        {
            Debug.Log("Ha ganado " + Color[turn]);
        }

        bool IsTicTacToe()
        {
            return IsTicTacToe('x') || IsTicTacToe('o');
        }

        bool IsTicTacToe(char token)
        {
            if (tokens[1,1]==token) {
                if (tokens[0,0]==token) {
                    return tokens[2,2]==token;
                }
                if (tokens[0,2]==token) {
                    return tokens[2,0]==token;
                }
                if (tokens[0,1]==token) {
                    return tokens[2,1]==token;
                }
                if (tokens[1,0]==token) {
                    return tokens[1,2]==token;
                }
                return false;
            }
            if (tokens[0,0]==token) {
                if (tokens[0,1]==token) {
                    return tokens[0,2]==token;
                }
                if (tokens[1,0]==token) {
                    return tokens[2,0]==token;
                }
                return false;
            }
            if (tokens[2,2]==token) {
                if (tokens[1,2]==token) {
                    return tokens[0,2]==token;
                }
                if (tokens[2,1]==token) {
                    return tokens[2,0]==token;
                }
                return false;
            }
            return false;
        }

        bool IsComplete()
        {
            var tokensCount = 0;
            
            for(var i = 0; i < 3; i++)
                for(var j = 0; j < 3; j++)
                    if(tokens[i, j] != '_')
                        tokensCount++;

            return tokensCount == 6;
        }

        public bool IsTileEmpty(int row, int column)
        {
            return tokens[row, column] == '_';
        }

        public bool IsTileFull(int row, int column, char color)
        {
            return tokens[row, column] == color;
        }
    }
}