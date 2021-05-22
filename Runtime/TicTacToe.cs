namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        public const int PlayersCount = 2;
        
        readonly Turn turn;
        readonly Board board;
        readonly Player[] players = new Player[PlayersCount];

        public TicTacToe()
        {
            turn = new Turn();
            board = new Board();
            for(var i = 0; i < PlayersCount; i++)
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