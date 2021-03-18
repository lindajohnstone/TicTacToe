namespace TicTacToe2D
{
    public class Notes
    {
        /*
            TODO: should Controller be renamed to GameController? - possibly more than one controller required
            TODO: does the field know how many fields or is this the responsibility of the board?
            TODO: input from player comes in as a string...
            TODO: input from player - responsibility of GameContext or Controller
            TODO: output to console - responsibility of GameContext or Controller
            
            Players                                     - Players
            Field                                       - Field
            StoreLocation - Coords, Field               - Coords
            DrawBoard                                   - Board
            Initialise                                  - Controller
            GetPlayers                                  - GameContext
            GetGameBoard                                - GameContext
            GetGameState                                - GameContext
            ImplementTurn                               - Controller
            PlayGame                                    - Controller
            IsValid - is player input valid             - Validations
            IsOccupied - is field already occupied      - Validations
            IsAWinningColumn                            - GamePredicate
            IsAWinningRow                               - GamePredicate
            IsAWinningDiagonal                          - GamePredicate
            IsADraw                                     - GamePredicate
            ConsoleReadLine                             - IInput, ConsoleInput
            ConsoleReadKey - has player pressed 'q'     - IInput, ConsoleInput
            ConsoleWrite - write output to console      - IOutput, ConsoleOutput
            ConsoleWriteLine - write output to console  - IOutput, ConsoleOutput
        */
    }
}