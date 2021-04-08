using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Controller
    {
        // Controls the game. input == Gamecontext, returns Gamecontext
        public GameContext Game { get; set; }
        public List<Player> Players { get; private set; }
        public Controller()
        {
            var game = new GameContext();
            Initialize(game);
        }
        public void Initialize(GameContext game)
        {
            var players = new List<Player> { Player.X, Player.O };
            Game = game;
            Players = players;
        }

        public GameContext ImplementTurn(in GameContext game) // in == constant input
        {
            var output = new ConsoleOutput();

            var input = new ConsoleInput();

            // prompt for move...
            OutputFormatter.PrintInstructions(output); // TODO: add WriteLine with extra parameters to allow string interpolation
            
            // get move
            Position playerMovePosition = null;
            do
            {
                try
                {
                    //. get player move
                    playerMovePosition = InputParser.GetPlayerMove(input);  // may throw InvalidMoveSyntaxException
                    //. validate move...
                    //Validations.ValidTurn(board, playerMovePosition);  // may throw InvalidMoveEntryException
                }
                catch (InvalidMoveEntryException ex)
                {
                    //. display this move is not valid message and try again
                    playerMovePosition = null;
                }
                catch (InvalidMoveSyntaxException ex)
                {
                    // display retry entering move message and try again...
                }
            }
            while (playerMovePosition == null);

            //. apply move to board.
            game.GameBoard.MovePlayer(playerMovePosition, FieldContents.x);
            //. do we have a winner?

            //. is the board full?

            return game;
        }

        private Validations ValidTurn()
        {
            throw new NotImplementedException();
        }

        public GameContext PlayGame(GameContext game) // should this be in GameContext?
        {
            var output = new ConsoleOutput();
            // display instructions
            output.ConsoleWriteLine("Welcome to Tic Tac Toe!");
            while (true)
            {
                foreach (var player in Players)
                {
                    ImplementTurn(game);
                }
                return game;
            }
            // EndGame
        }
    }
}