using System;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public class Put
    {
        char[,] tokens;

        public Put(char[,] tokens)
        {
            this.tokens = tokens;
        }

        public void DoPut(int turn, TicTacToe ticTacToe)
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