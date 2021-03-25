using System;
using System.Collections.Generic;

namespace TicTacToe2D
{
    public class GameContext
    {
        // stores Board, Player, game state
        // accesses board, player, validations?, gamepredicate?
        public Board GameBoard { get; private set; }
        public Player Player { get; private set; }
        private Validations _validations;
        private GamePredicate _conditions;

        public GameContext(Player player, Board board, Validations validations, GamePredicate conditions)
        {
            GameBoard = new Board(3);
            Player = player;
            _validations = validations;
            _conditions = conditions;
        }
        
        public Board GetGameBoard()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayers()
        {
            throw new NotImplementedException();
        }

        public void GameState()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return obj is GameContext context &&
                   EqualityComparer<Board>.Default.Equals(GameBoard, context.GameBoard) &&
                   Player == context.Player &&
                   EqualityComparer<Validations>.Default.Equals(_validations, context._validations) &&
                   EqualityComparer<GamePredicate>.Default.Equals(_conditions, context._conditions);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GameBoard, Player, _validations, _conditions);
        }
    }
}