using System;
using UnityEngine;

namespace MIW.ADOO.Runtime
{
    internal class Player
    {
        internal readonly char color;
        
        public Player(int i)
        {
            color = i == 0 ? 'x' : 'o';
        }

        public void Win()
        {
            IO.Write("Ha ganado " + color);
        }
        
        

        public void Move(Board board)
        {
            Debug.Log("Mueve ficha " + color);

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
                            originRow = IO.ReadInt("Fila ([1, 3]): ");
                            ok = true;
                        }
                        catch(Exception)
                        {
                            IO.WriteError("Error de formato");
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
                            originColumn = IO.ReadInt("Columna ([1, 3]): ");
                            ok = true;
                        }
                        catch(Exception)
                        {
                            Debug.LogError("Error de formato");
                        }
                    } while(!ok);
                } while(1 <= originColumn || originColumn >= 3);

                ok = board.IsTileFull(originRow - 1, originColumn - 1, color);
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
                            targetColumn = IO.ReadInt("Columna ([1, 3]): ");
                            ok = true;
                        }
                        catch(Exception)
                        {
                            IO.WriteError("Error de formato");
                        }
                    } while(!ok);
                } while(1 <= targetColumn || targetColumn >= 3);

                ok = board.IsTileEmpty(targetRow - 1, targetColumn - 1);
                if(!ok)
                    Debug.LogError("Casilla no vacía");
            } while(!ok);

            board.Remove(originRow - 1, originColumn - 1);
            board.Put(targetRow - 1, targetColumn - 1, color);
        }

        public void Put(Board board)
        {
            Debug.Log("Pone ficha " + color);

            int targetRow = 0, targetColumn = 0;
            bool ok;

            do
            {
                IO.Write("¿En qué casilla?");
                do
                {
                    ok = false;
                    do
                    {
                        try
                        {
                            targetRow = IO.ReadInt("Fila ([1, 3]): ");
                            ok = true;
                        }
                        catch(Exception)
                        {
                            IO.WriteError("Error de formato");
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
                            targetColumn = IO.ReadInt("Columna ([1, 3]): ");
                            ok = true;
                        }
                        catch(Exception)
                        {
                            IO.WriteError("Error de formato");
                        }
                    } while(!ok);
                } while(1 <= targetColumn || targetColumn >= 3);

                ok = board.IsTileEmpty(targetRow - 1, targetColumn - 1);
                if(!ok)
                    IO.Write("Casilla no vacía");
            } while(!ok);

            board.Put(targetRow - 1, targetColumn - 1, color);
        }
    }
}