using System;

namespace TicTacToe2D
{
    public class Validations
    {
        // validates player input to ensure that the requested player position is within the board
        // and also is not already occupied
        //private GameContext _game;

        public Validations()
        {
            
        }

        public bool IsOccupied(GameContext game)
        {
            throw new NotImplementedException();
        }

        public static bool ValidTurn(Board board, Position playerMovePosition)
        {
            return board.GetField(playerMovePosition) == FieldContents.empty;
        }
    }
}