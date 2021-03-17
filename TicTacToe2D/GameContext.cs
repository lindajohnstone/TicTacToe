using System;

namespace TicTacToe2D
{
    public class GameContext
    {
        // stores Board, Player, game state
        // accesses board, player, validations?, gamepredicate?
        public Board GameBoard { get; private set; }
        public Players Players { get; private set; }
        private Validations _validations;
        private GamePredicate _conditions;

        public GameContext()
        {
            
        }
        public Board GetGameBoard()
        {
            throw new NotImplementedException();
        }

        public Players GetPlayers()
        {
            throw new NotImplementedException();
        }

        public void GameState()
        {
            throw new NotImplementedException();
        }
    }
}