using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe2D
{
    public class GameContext
    {
        // stores Board, Player, game state
        // accesses board, player, validations?
        public Board GameBoard { get; private set; }
        public List<Player> Players { get; private set; } 
        private Validations _validations;
        public IInput ConsoleInput { get; private set; }
        public IOutput ConsoleOutput { get; private set; }
        
        public GameContext(Board board, List<Player> players) 
        {
            var validations = new Validations();
            Initialize(players, board, validations);
        }
        
        public void Initialize(List<Player> players, Board board, Validations validations)
        {
            var input = new ConsoleInput();
            var output = new ConsoleOutput();
            GameBoard = board;
            Players = players;
            _validations = validations;
            ConsoleInput = input;
            ConsoleOutput = output;
        }
        
        public Board GetGameBoard()
        {
            throw new NotImplementedException();
        }

        public Player GetCurrentPlayer()
        {
            // check how many empty fields in board
            // if modulus == 1, Player == X, else Y
            // TODO: if board is full, still returns a value 
            if (GameBoard.GetAllPositions().Where((x) => GameBoard.GetField(x) == FieldContents.empty).Count() % 2 == 1)
            {
                return Players[0];
            }
            return Players[1];
        }

        public List<Player> GetPlayers()
        {
            Players = new List<Player>();
            foreach(Player player in Enum.GetValues(typeof(Player)))
            {
                Players.Add(player);
            }
            return Players;
        }

        public FieldContents PlayerFieldContents(Player player)
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

        public bool GameState(Player player)// TODO: win, draw, ended by player // enum? // switch?? // rewrite tests
        {
            var condition = new GamePredicate();
            if (condition.IsWinningBoard(GameBoard, GameBoard.GetWinningLines(), PlayerFieldContents(player)))
            {
                OutputFormatter.PrintWinGame(player, ConsoleOutput);
                return true;
            }
            if (condition.IsADraw(GameBoard))
            {
                OutputFormatter.PrintDrawnGame(GameBoard, condition, ConsoleOutput);
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return obj is GameContext context &&
                   EqualityComparer<Board>.Default.Equals(GameBoard, context.GameBoard) &&
                   Players == context.Players &&
                   EqualityComparer<Validations>.Default.Equals(_validations, context._validations);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GameBoard, Players, _validations);
        }
    }
}