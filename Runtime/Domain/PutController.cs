using MIW.ADOO.Runtime.Utils;
using System.Diagnostics;

namespace MIW.ADOO.Runtime
{
    internal class PutController
    {
        readonly Turn turn;
        readonly Board board;

        Coord target;

        public PutController(Turn turn, Board board)
        {
            Debug.Assert(turn != null);
            Debug.Assert(board != null);
            
            this.turn = turn;
            this.board = board;
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