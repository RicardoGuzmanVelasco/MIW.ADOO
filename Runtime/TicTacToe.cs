namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        int turn;
        Board board;

        public TicTacToe()
        {
            turn = 0;
            board = new Board();
        }
        
        public void Play()
        {
            do
            {
                board.Write();
                if(!board.IsComplete())
                    board.Put(turn, this);
                else
                    board.Move(turn, this);
                turn = (turn + 1) % 2;
            } while(!board.IsTicTacToe());

            board.Write();
            board.Win(turn);
        }
    }
}