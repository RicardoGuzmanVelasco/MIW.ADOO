using System;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public class Board
    {
        public static readonly char[] Color = {'x', 'o'};

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
        
        public void Win(int turn)
        {
            Debug.Log("Ha ganado " + Color[turn]);
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

        bool IsTileEmpty(int row, int column)
        {
            return tokens[row, column].Equals('_');
        }

        bool IsTileFull(int row, int column, char color)
        {
            return tokens[row, column].Equals(color);
        }

        public void Move(int turn)
        {
            Debug.Log("Mueve ficha " + Color[turn]);

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

                ok = IsTileFull(originRow - 1, originColumn - 1, Color[turn]);
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

                ok = IsTileEmpty(targetRow - 1, targetColumn - 1);
                if(!ok)
                    Debug.LogError("Casilla no vacía");
            } while(!ok);

            tokens[originRow - 1, originColumn - 1] = '_';
            tokens[targetRow - 1, targetColumn - 1] = Color[turn];
        }

        public void Put(int turn)
        {
            Debug.Log("Pone ficha " + Color[turn]);

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

                ok = IsTileEmpty(targetRow - 1, targetColumn - 1);
                if(!ok)
                    IO.Write("Casilla no vacía");
            } while(!ok);

            tokens[targetRow - 1, targetColumn - 1] = Color[turn];
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
    }
}