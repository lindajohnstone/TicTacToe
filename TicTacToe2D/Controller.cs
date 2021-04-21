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
            // display instructions
            output.ConsoleWriteLine("Welcome to Tic Tac Toe!\n");
            while (true)
            {
                foreach (var player in game.Players)
                {
                    ImplementTurn(game);
                    game.GameState(); //TODO: where to place so next players' instructions don't display
                }
            }


            // EndGame
        }

        // private bool EndGame(GameContext game, ConsoleOutput output, Player player)
        // {
        //     //. is there a winner
        //     var condition = new GamePredicate();
        //     if (condition.IsWinningBoard(GameBoard, GameBoard.GetWinningLines(), game.PlayerFieldContents(player)))
        //     {
        //         OutputFormatter.PrintWinGame(player, output);
        //         return true;
        //     }
        //     //. is the board full?
        //     if (condition.IsADraw(game.GameBoard))
        //     {
        //         OutputFormatter.PrintDrawnGame(GameBoard, condition, output);
        //         return true;
        //     }
        //     return false;
        // }

        public void ImplementTurn(GameContext game)
        {
            var output = new ConsoleOutput();

            var input = new ConsoleInput();

            var player = game.GetCurrentPlayer();
            // prompt for move...
            OutputFormatter.PrintBoard(game.GameBoard, output);
            output.ConsoleWriteLine("");
            OutputFormatter.PrintInstructions(player, output);

            // get move
            Position playerMovePosition = null;
            do
            {
                try
                {
                    //. get player move
                    var value = input.ConsoleReadLine();
                    output.ConsoleWriteLine("");
                    if(InputParser.PlayerEndsGame(player, value, output))
                    {
                        Environment.Exit(0);
                    }
                    playerMovePosition = InputParser.GetPlayerMove(value);  // may throw InvalidMoveSyntaxException
                    //. validate move...
                    Validations.ValidTurn(game.GameBoard, playerMovePosition);  // may throw InvalidMoveEntryException 
                }
                catch (InvalidMoveEntryException ex) 
                {
                    //. display this move is not valid message and try again
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

            //. apply move to board.
            var fieldContents = new FieldContents();
            
            fieldContents = game.PlayerFieldContents(player);
            game.GameBoard.MovePlayer(playerMovePosition, fieldContents);
        }

        private Validations ValidTurn()
        {
            throw new NotImplementedException();
        }
    }
}