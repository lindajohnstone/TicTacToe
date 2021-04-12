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
            var game = new GameContext();
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

        public void ImplementTurn(GameContext game)
        {
            var output = new ConsoleOutput();

            var input = new ConsoleInput();

            // prompt for move...
            OutputFormatter.PrintInstructions(game.GetCurrentPlayer(game));
            OutputFormatter.DrawBoard(game.GameBoard, output);
            // OutputFormatter.DrawBoard(board, player, output);
            // get move
            Position playerMovePosition = null;
            do
            {
            try
            {
                //. get player move
                var value = input.ConsoleReadLine();
                playerMovePosition = InputParser.GetPlayerMove(value);  // may throw InvalidMoveSyntaxException
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
            var fieldContents = new FieldContents();
            fieldContents = PlayerFieldContents(game.GetCurrentPlayer(game));
            Game.GameBoard.MovePlayer(playerMovePosition, fieldContents);
        }


        private FieldContents PlayerFieldContents(Player player)
        {
            FieldContents fieldContents;
            if (player == Game.Players[0])
            {
                fieldContents = FieldContents.x;
            }
            else
            {
                fieldContents = FieldContents.y;
            }

            return fieldContents;
        }

        

        private Validations ValidTurn()
        {
            throw new NotImplementedException();
        }

        public GameContext PlayGame(GameContext game) 
        {
            var output = new ConsoleOutput();
            // display instructions
            output.ConsoleWriteLine("Welcome to Tic Tac Toe!");
            // TODO: ?? while(!EndGame) - board is not full, there is no win or player hasn't pressed 'q'
            while (true)
            {
                foreach (var player in game.Players) // TODO: loop should not be a foreach - only loops once for each player
                {
                    ImplementTurn(game);

                    //. is there a winner
                    var winner = new GamePredicate();
                    IsWinningBoard(player, winner);
                    // winner.IsWinningBoard(GameBoard, GameBoard.GetWinningLines(), PlayerFieldContents(player))
                    //. is the board full?
                    winner.IsADraw(game.GameBoard);
                }
            }
            return game;

            
            // EndGame
        }

        public bool IsWinningBoard(Player player, GamePredicate winner)// TODO: should this method be private?
        {
            return winner.IsWinningBoard(GameBoard, GameBoard.GetWinningLines(), PlayerFieldContents(player));
        }
    }
}