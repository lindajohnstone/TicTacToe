using System;
using System.Collections;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class Controller
    {
        // Controls the game. input == Gamecontext, returns Gamecontext
        public GameContext Game { get; set; }

        public Board GameBoard { get; private set; }
        public List<Player> Players { get; private set; }

        public Queue TurnQueue { get; set; }
        public Controller()
        {
            Initialize();
        }
        public void Initialize()
        {
            Players = new List<Player> { Player.X, Player.O };
            GameBoard = new Board(3);
            Game = new GameContext(GameBoard, Players);
        }

        public void PlayGame(GameContext game)
        {
            var output = new ConsoleOutput();
            OutputFormatter.PrintWelcome(game.GameBoard, output);
            while (true)
            {
                OutputFormatter.PrintInstructions(game.GetCurrentPlayer(), output);
                ImplementTurn(game);
                OutputFormatter.PrintNewBoard(game.GameBoard, output);
                if (GamePredicate.IsWinningBoard(game)) 
                {
                    OutputFormatter.PrintWinGame(game.GetCurrentPlayer(), output);
                    Environment.Exit(0);
                }
                if (GamePredicate.IsADraw(game))
                {
                    OutputFormatter.PrintDrawnGame(output);
                    Environment.Exit(0);
                }
                game.SetNextPlayer();
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
                    playerMovePosition = InputParser.GetPlayerMove(value);  
                    Validations.ValidTurn(game.GameBoard, playerMovePosition);  
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