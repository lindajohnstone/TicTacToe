using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Controller
    {
        // Controls the game. input == Gamecontext, returns Gamecontext
        public GameContext Game { get; set; }

        public Board GameBoard { get; private set; }
        public List<Player> Players { get; private set; }
        public Controller()
        {
            var game = new GameContext(GameBoard, Players);
            Initialize(game);
        }
        public void Initialize(GameContext game)
        {
            var players = new List<Player> { Player.X, Player.O };
            var board = new Board(3);
            Game = game;
            Players = players;
            GameBoard = board;
        }

        public void PlayGame(GameContext game)
        {
            var output = new ConsoleOutput();
            OutputFormatter.PrintWelcome(game.GameBoard, output);
            while (true)
            {
                if (game.GameState() == 0) 
                {
                    Environment.Exit(0);
                }
                else
                {
                    OutputFormatter.PrintInstructions(game.GetCurrentPlayer(), output);
                    ImplementTurn(game);
                    OutputFormatter.PrintNewBoard(game.GameBoard, output);
                }
            }
        }

        public void ImplementTurn(GameContext game)
        {
            var output = new ConsoleOutput();

            var input = new ConsoleInput();

            var player = game.GetCurrentPlayer();
            
            Position playerMovePosition = null;
            do
            {
                try
                {
                    var value = input.ConsoleReadLine();
                    output.ConsoleWriteLine("");
                    if(InputParser.PlayerEndsGame(player, value, output))
                    {
                        Environment.Exit(0);
                    }
                    playerMovePosition = InputParser.GetPlayerMove(value);  // may throw InvalidMoveSyntaxException
                    Validations.ValidTurn(game.GameBoard, playerMovePosition);  // may throw InvalidMoveEntryException 
                }
                catch (InvalidMoveEntryException ex) 
                {
                    output.ConsoleWriteLine(ex.Message);
                    playerMovePosition = null;
                }
                catch (InvalidMoveSyntaxException ex)
                {
                    output.ConsoleWriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    output.ConsoleWriteLine(ex.Message);
                    playerMovePosition = null;
                }
            }
            while (playerMovePosition == null);

            var fieldContents = new FieldContents();
            fieldContents = game.PlayerFieldContents(player);
            game.GameBoard.MovePlayer(playerMovePosition, fieldContents);
        }
    }
}