using MIW.ADOO.Runtime.Utils;
using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    internal class MoveController
    {
        readonly Turn turn;
        readonly Board board;

        Coord origin;
        Coord target;

        public MoveController(Turn turn, Board board)
        {
            Debug.Assert(turn != null);
            Debug.Assert(board != null);

            this.turn = turn;
            this.board = board;
        }

        public void Move()
        {
            IO.Write("Mueve ficha " + turn.Current());

            var origin = new Coord();
            bool ok;

            do
            {
                origin.Read("De");
                ok = board.IsTileFull(origin, turn.Current());
                if(!ok)
                    IO.Write("Esa casilla no está ocupada por fichas de " + turn.Current());
            } while(!ok);

            board.Remove(origin);
            Put();
        }
        
        public void Put()
        {
            var target = new Coord();
            bool ok;
            
            IO.Write("Pone el jugador " + turn.Current());

            do
            {
                target.Read("En");
                
                ok = board.IsTileEmpty(target);
                if(!ok)
                    IO.Write("Esa casilla no está vacía");
            } while(!ok);

            board.Put(target, turn.Current());
            board.Write();
            
            if(board.IsTicTacToe(turn.Current()))
                IO.Write("Ha ganado " + turn.Current());
            else
                turn.Change();
        }
    }
}