using System;

namespace TicTacToe2D
{
    public class Controller
    {
        // Controls the game. input == Gamecontext, returns Gamecontext
        private GameContext _game;

        public Controller(GameContext game)
        {
            _game = game;
        }
        public GameContext Initialise()
        {
            throw new NotImplementedException();
        }

        public GameContext ImplementTurn(in GameContext game) // in == constant input
        {
            throw new NotImplementedException();
        }

        public GameContext PlayGame(GameContext game) // should this be in GameContext?
        {
            throw new NotImplementedException();
        }
    }
}