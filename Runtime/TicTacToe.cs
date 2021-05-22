namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        int turn;
        readonly Board board;
        Player[] players;

        public TicTacToe()
        {
            turn = 0;
            board = new Board();
            for(var i = 0; i < 2; i++)
                players[i] = new Player(i);
        }
        
        public void Play()
        {
            do
            {
                board.Write();
                if(!board.IsComplete())
                    players[(turn + 1) % 2].Put(turn, board);
                else
                    players[(turn + 1) % 2].Move(turn, board);
                turn = (turn + 1) % 2;
            } while(!board.IsTicTacToe());

            board.Write();
            players[(turn + 1) % 2].Win();
        }
    }
}