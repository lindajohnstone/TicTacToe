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

        public GameContext PlayGame(GameContext game)
        {
            var output = new ConsoleOutput();
            // display instructions
            output.ConsoleWriteLine("Welcome to Tic Tac Toe!\n");
            
            while (true)
            {
                foreach (var player in game.Players) 
                {
                    ImplementTurn(game);
                    //. is there a winner
                    var winner = new GamePredicate();
                    //IsWinningBoard(player, winner);
                    winner.IsWinningBoard(GameBoard, GameBoard.GetWinningLines(), PlayerFieldContents(player));
                    //. is the board full?
                    winner.IsADraw(game.GameBoard);
                }
            }
            //return game;


            // EndGame
        }


        public void ImplementTurn(GameContext game)
        {
            var output = new ConsoleOutput();

            var input = new ConsoleInput();

            var player = game.GetCurrentPlayer(game);
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
                    playerMovePosition = InputParser.GetPlayerMove(value);  // may throw InvalidMoveSyntaxException
                    //. validate move...
                    Validations.ValidTurn(game.GameBoard, playerMovePosition);  // may throw InvalidMoveEntryException 
                }
                catch (InvalidMoveEntryException ex) // TODO: where to use 'ex'
                {
                    //. display this move is not valid message and try again
                    output.ConsoleWriteLine("Oh no, a piece is already at this place! Try again...");
                    playerMovePosition = null;
                }
                catch (InvalidMoveSyntaxException ex)// TODO: where to use 'ex'
                {
                    output.ConsoleWriteLine("Invalid format. Please try again...");
                }
            }
            while (playerMovePosition == null);

            //. apply move to board.
            var fieldContents = new FieldContents();
            
            fieldContents = PlayerFieldContents(player);
            game.GameBoard.MovePlayer(playerMovePosition, fieldContents);
        }

        private FieldContents PlayerFieldContents(Player player)
        {
            FieldContents fieldContents;
            if (player == Players[0]) 
            {
                fieldContents = FieldContents.x;
            }
            else
            {
                fieldContents = FieldContents.y;
            }

            return fieldContents;
        }

        public bool EndGame(string playerInput, IOutput output, Player player, IInput input, bool isWinningGame, bool isDrawnGame) 
        // TODO: too many parameters? 
        //  adding playerInput to PlayGame while loop?
        {
            if (InputParser.PlayerEndsGame(player, playerInput, output))
            {
                return true;
            }
            if (isWinningGame)
            {
                return true;
            }
            if (isDrawnGame)
            {
                return true;
            }
            return false;
        }

        private Validations ValidTurn()
        {
            throw new NotImplementedException();
        }

        public bool IsWinningBoard(Player player, GamePredicate winner)// TODO: should this method be private?
        {
            return winner.IsWinningBoard(GameBoard, GameBoard.GetWinningLines(), PlayerFieldContents(player));
        }
    }
}