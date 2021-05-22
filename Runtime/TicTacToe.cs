namespace MIW.ADOO.Runtime
{
    public class TicTacToe
    {
        const int PlayersCount = 2;
        
        readonly Board board;
        readonly Player[] players;
        readonly Turn turn;

        public TicTacToe()
        {
            board = new Board(PlayersCount);
            
            players = new Player[PlayersCount];
            for(var i = 0; i < PlayersCount; i++)
                players[i] = new Player(i, PlayersCount, board);
            
            turn = new Turn(players);
        }
        
        public void Play()
        {
            do
            {
                board.Write();
                if(!board.IsComplete())
                    turn.Current().Put();
                else
                    turn.Current().Move();
                turn.Change();
            } while(!board.IsTicTacToe());

            board.Write();
            turn.Next().Win();
        }
    }
}