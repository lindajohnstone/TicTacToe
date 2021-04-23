using System;

namespace TicTacToe2D
{
    public class Validations
    {
        // validates player input to ensure that the requested player position is within the board
        // and also is not already occupied
        //private GameContext _game;lic static bool ValidTurn(Board board, Position playerMovePosition)
        public Validations()
        {
            
        }

        public static bool ValidTurn(Board board, Position playerMovePosition)
        {
            if(board.GetField(playerMovePosition) != FieldContents.empty)
            {
                throw new InvalidMoveEntryException();
            }
            return board.GetField(playerMovePosition) == FieldContents.empty;
        }
    }
}