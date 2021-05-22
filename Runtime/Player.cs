using System;

namespace MIW.ADOO.Runtime
{
    internal class Player
    {
        internal readonly Color color;
        
        public Player(int i) => color = (Color)(i+1);

        public void Win() => IO.Write("Ha ganado " + color);

        public void Move(Board board)
        {
            IO.Write("Mueve ficha " + color);

            var origin = new Coord();
            bool ok;

            do
            {
                origin.Read("De");
                ok = board.IsTileFull(origin, color);
                if(!ok)
                    IO.Write("Esa casilla no está ocupada por fichas de " + color);
            } while(!ok);

            board.Remove(origin);
            Put(board, "Hacia", origin);
        }

        public void Put(Board board)
        {
            IO.Write("Pone el jugador " + color);
            Put(board, "En", null);
        }
        void Put(Board board, string title, Coord fromCoord)
        {
            var target = new Coord();
            bool ok;

            do
            {
                target.Read(title);
                
                ok = board.IsTileEmpty(target);
                if(!ok)
                    IO.Write("Esa casilla no está vacía");

                ok = target.Equals(fromCoord);
                if(!ok)
                    IO.Write("No se puede poner de donde se quitó");
            } while(!ok);

            board.Put(target, color);
        }
    }
}