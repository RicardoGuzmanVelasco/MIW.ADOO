namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        Turn turn;
        readonly Board board;
        Player[] players;

        public TicTacToe()
        {
            turn = new Turn();
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
                    players[turn.Current()].Put(board);
                else
                    players[turn.Current()].Move(board);
                turn.Change();
            } while(!board.IsTicTacToe());

            board.Write();
            players[turn.Next()].Win();
        }
    }
}