using System;

namespace TicTacToe2D
{
    public class GameContext
    {
        // stores Board, Player, game state
        // accesses board, player, validations?, gamepredicate?
        public Board GameBoard { get; private set; }
        public Player Player { get; private set; }
        private Validations _validations;
        private GamePredicate _conditions;

        public GameContext()
        {
            
        }
        public Board GetGameBoard()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayers()
        {
            throw new NotImplementedException();
        }

        public void GameState()
        {
            throw new NotImplementedException();
        }
    }
}