using MIW.ADOO.Runtime.Utils;

namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        const int PlayersCount = 2;
        
        readonly Board board;
        readonly Turn turn;
        
        readonly PutController putController;
        readonly MoveController moveController;

        public TicTacToe()
        {
            turn = new Turn();
            board = new Board(PlayersCount);

            putController = new PutController(turn, board);
            moveController = new MoveController(turn, board);
        }
        
        public void Play()
        {
            do
            {
                board.Write();
                if(!board.IsComplete())
                    putController.Put();
                else
                    moveController.Move();
                turn.Change();
            } while(!board.IsTicTacToe());

            board.Write();
            IO.Write("Winner: " + turn.Next());
        }
    }
}