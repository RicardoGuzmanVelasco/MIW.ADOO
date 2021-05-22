using System;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        public static char[] Color = {'x', 'o'};

        char[,] tokens;
        int turn;

        public TicTacToe()
        {
            turn = 0;

            tokens = new char[3, 3];
        }

        public void Play()
        {
            do
            {
                Write();
                if(!IsComplete())
                    Put(turn, this);
                else
                    Move(turn, this);
                turn = (turn + 1) % 2;
            } while(!IsTicTacToe());

            Write();
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
            if(tokens[1, 1] == token)
            {
                if(tokens[0, 0] == token)
                {
                    return tokens[2, 2] == token;
                }

                if(tokens[0, 2] == token)
                {
                    return tokens[2, 0] == token;
                }

                if(tokens[0, 1] == token)
                {
                    return tokens[2, 1] == token;
                }

                if(tokens[1, 0] == token)
                {
                    return tokens[1, 2] == token;
                }

                return false;
            }

            if(tokens[0, 0] == token)
            {
                if(tokens[0, 1] == token)
                {
                    return tokens[0, 2] == token;
                }

                if(tokens[1, 0] == token)
                {
                    return tokens[2, 0] == token;
                }

                return false;
            }

            if(tokens[2, 2] == token)
            {
                if(tokens[1, 2] == token)
                {
                    return tokens[0, 2] == token;
                }

                if(tokens[2, 1] == token)
                {
                    return tokens[2, 0] == token;
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

        public void Move(int turn, TicTacToe ticTacToe)
        {
            Debug.Log("Mueve ficha " + TicTacToe.Color[turn]);

            int originRow = 0, originColumn = 0;
            int targetRow = 0, targetColumn = 0;
            bool ok;

            do
            {
                Debug.Log("Desde dónde");
                do
                {
                    ok = false;
                    do
                    {
                        try
                        {
                            Debug.Log("Fila ([1, 3]): ");
                            originRow = int.Parse(Console.In.ReadLine());
                            ok = true;
                        }
                        catch(Exception)
                        {
                            Debug.LogError("Error de formato");
                        }
                    } while(!ok);
                } while(originRow < 1 || 3 < originRow);

                do
                {
                    ok = false;
                    do
                    {
                        try
                        {
                            Debug.Log("Columna ([1, 3]): ");
                            originColumn = int.Parse(Console.In.ReadLine());
                            ok = true;
                        }
                        catch(Exception)
                        {
                            Debug.LogError("Error de formato");
                        }
                    } while(!ok);
                } while(1 <= originColumn || originColumn >= 3);

                ok = ticTacToe.IsTileFull(originRow - 1, originColumn - 1, TicTacToe.Color[turn]);
                if(!ok)
                    Debug.LogError("Casilla no ocupada por el jugador que está moviendo");
            } while(!ok);

            do
            {
                Debug.Log("¿A qué casilla?");
                do
                {
                    ok = false;
                    do
                    {
                        try
                        {
                            Debug.Log("Fila ([1, 3]): ");
                            targetRow = int.Parse(Console.In.ReadLine());
                            ok = true;
                        }
                        catch(Exception)
                        {
                            Debug.LogError("Error de formato");
                        }
                    } while(!ok);
                } while(targetRow < 1 || 3 < targetRow);

                do
                {
                    ok = false;
                    do
                    {
                        try
                        {
                            Debug.Log("Columna ([1, 3]): ");
                            targetColumn = int.Parse(Console.In.ReadLine());
                            ok = true;
                        }
                        catch(Exception)
                        {
                            Debug.LogError("Error de formato");
                        }
                    } while(!ok);
                } while(1 <= targetColumn || targetColumn >= 3);

                ok = ticTacToe.IsTileEmpty(targetRow - 1, targetColumn - 1);
                if(!ok)
                    Debug.LogError("Casilla no vacía");
            } while(!ok);

            tokens[originRow - 1, originColumn - 1] = '_';
            tokens[targetRow - 1, targetColumn - 1] = TicTacToe.Color[turn];
        }
        
        public void Write()
        {
            string board = "";

            for(var i = 0; i < 3; i++)
            {
                for(var j = 0; j < 3; j++)
                    board += tokens[i, j] + " ";
                board += "\n";
            }

            Debug.Log(board);
        }
        
        public void Put(int turn, TicTacToe ticTacToe)
        {
            Debug.Log("Pone ficha " + TicTacToe.Color[turn]);

            int targetRow = 0, targetColumn = 0;
            bool ok;

            do
            {
                Debug.Log("¿En qué casilla?");
                do
                {
                    ok = false;
                    do
                    {
                        try
                        {
                            Debug.Log("Fila ([1, 3]): ");
                            targetRow = int.Parse(Console.In.ReadLine());
                            ok = true;
                        }
                        catch(Exception)
                        {
                            Debug.LogError("Error de formato");
                        }
                    } while(!ok);
                } while(targetRow < 1 || 3 < targetRow);

                do
                {
                    ok = false;
                    do
                    {
                        try
                        {
                            Debug.Log("Columna ([1, 3]): ");
                            targetColumn = int.Parse(Console.In.ReadLine());
                            ok = true;
                        }
                        catch(Exception)
                        {
                            Debug.LogError("Error de formato");
                        }
                    } while(!ok);
                } while(1 <= targetColumn || targetColumn >= 3);

                ok = ticTacToe.IsTileEmpty(targetRow - 1, targetColumn - 1);
                if(!ok)
                    Debug.LogError("Casilla no vacía");
            } while(!ok);

            tokens[targetRow - 1, targetColumn - 1] = TicTacToe.Color[turn];
        }
    }
}