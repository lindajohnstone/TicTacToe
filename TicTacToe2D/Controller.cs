using System;
using System.Collections;
using System.Collections.Generic;
using TicTacToe2D.Exceptions;

namespace TicTacToe2D
{
    public class Controller
    {
        // Controls the game. input == Gamecontext, returns Gamecontext
        public GameContext Game { get; set; }

        public Board GameBoard { get; private set; }
        public List<Player> Players { get; private set; }

        public Queue TurnQueue { get; set; }
        public Controller(Board board)
        {
            Initialize(board);
        }
        public void Initialize(Board board)
        {
            Players = new List<Player> { Player.X, Player.O };
            GameBoard = board;
            Game = new GameContext(GameBoard, Players);
        }

        public void PlayGame(GameContext game, IOutput output, IInput input, OutputFormatter outputFormatter)
        {
            outputFormatter.PrintWelcome(output);
            outputFormatter.PrintBoard(game.GameBoard, output);
            while (true)
            {
                outputFormatter.PrintInstructions(game.GetCurrentPlayer(), output);
                try
                {
                    ImplementTurn(game, output, input);
                }
                catch(PlayerAbortsGameException ex)
                {
                    outputFormatter.PrintEndGame(game.GetCurrentPlayer(), output);
                    break;
                }
                outputFormatter.PrintNewBoard(game.GameBoard, output);
                if (GamePredicate.IsWinningBoard(game)) 
                {
                    outputFormatter.PrintWinGame(game.GetCurrentPlayer(), output);
                    break;
                }
                if (GamePredicate.IsADraw(game))
                {
                    outputFormatter.PrintDrawnGame(output);
                    break;
                }
                game.SetNextPlayer();
            }
        }

        public void ImplementTurn(GameContext game, IOutput output, IInput input)
        {
            var player = game.GetCurrentPlayer();
            
            Position playerMovePosition = null;
            do
            {
                try
                {
                    var value = input.ConsoleReadLine();
                    output.ConsoleWriteLine("");
                    InputParser.PlayerEndsGame(player, value);
                    
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