using System;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    public class Move
    {
        char[,] tokens;

        public Move(char[,] tokens)
        {
            this.tokens = tokens;
        }

        public void DoMove(int turn, TicTacToe ticTacToe)
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
    }
}