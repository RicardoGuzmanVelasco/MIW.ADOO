namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        int turn;
        readonly Board board;

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
                    board.Put(turn);
                else
                    board.Move(turn);
                turn = (turn + 1) % 2;
            } while(!board.IsTicTacToe());

            board.Write();
            board.Win(turn);
        }
    }
}