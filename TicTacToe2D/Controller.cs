using System;

namespace TicTacToe2D
{
    public class Controller
    {
        // Controls the game. input == Gamecontext, returns Gamecontext

        public Controller()
        {
            
        }
        public GameContext Initialize()
        {
            throw new NotImplementedException();
        }

        public GameContext ImplementTurn(in GameContext game) // in == constant input
        {
            var output = new ConsoleOutput();
            OutputFormatter.PrintInstructions(output);
            var input = new ConsoleInput();
            var playerInput = input.ConsoleReadLine();
            var value = InputParser.ValidatePlayerInput(playerInput);
            //game.GameBoard.MovePlayer(value, FieldContents.x);

            return game;
        }

        private Validations ValidTurn()
        {
            throw new NotImplementedException();
        }

        public GameContext PlayGame(GameContext game) // should this be in GameContext?
        {
            ImplementTurn(game);
            return game;
        }
        // EndGame
    }
}