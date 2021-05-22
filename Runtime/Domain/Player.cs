using System;
using System.Diagnostics;
using MIW.ADOO.Runtime.Utils;

namespace MIW.ADOO.Runtime
{
    public class Player
    {
        internal readonly Color color;

        readonly Board board;
        
        public Player(int playerIndex, int numPlayers, Board board)
        {
            Debug.Assert(numPlayers > 1);
            var playersRange = new ClosedInterval(0, numPlayers - 1);
            Debug.Assert(playersRange.Includes(playerIndex));
            Debug.Assert(board != null);

            color = (Color)playerIndex;
            this.board = board;
        }

        public void Win() => IO.Write("Ha ganado " + color);

        public void Move()
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

        public void Put()
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