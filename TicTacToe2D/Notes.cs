namespace TicTacToe2D
{
    public class Notes
    {
        /*
                Class               Methods / Properties                            Used by
            1/  Player              - enum of Player values                         - GamePredicate
                                                                                    - GameContext
                                                                                    - ConsoleInput
                                                                                    - Validations
                                                                                    - Turn
            2/  FieldContents       - enum of Field state                           - GamePredicate
                                                                                    - Field  
            3/  Position            - Equals                                        - Board
                                    - GetHashCode                                   - Turn
                                    - OperatorOverride                              
                                    - operator ==                                   
                                    - operator !=                                   
            4/  IInput                      
            5/  IOutput
            6/  ConsoleInput        - ConsoleReadLine
                                    - ConsoleReadKey    - has player pressed 'q'
            7/  ConsoleOutput       - ConsoleWriteLine                              
                                    - ConsoleWrite
                                    - DrawBoard
            8/  Controller          - Initialise
                                    - ImplementTurn
                                    - Playgame
            9/  GameContext         - GetPlayers                                  
                                    - GetGameBoard                                
                                    - GetGameState                                
            10/ Validations         - IsValid - is player input valid             
                                    - IsOccupied - is field already occupied      
            11/ GamePredicate       - IsAWinningColumn                            
                                    - IsAWinningRow                               
                                    - IsAWinningDiagonal                          
                                    - IsADraw              
            12/ Board               - property Dictionary FieldDictionary                         - GamePredicate
                                    - property int Width
                                    - property int Height
                                    - property List<List<Position>> WInningLines
                                    - property List<Position> AllPositions
                                    - Initialize
                                    - BoardInitializer
                                    - CreateWinningLines
                                    - CreateWinningLine
                                    - CreateAllPositions
                                    - MovePlayer
                                    - GetField
                                    - SetField
                                    - EnsureValidPosition
                                    - GetWinningLines
                                    - OperatorOverride
                                    - GetAllPositions
                                    - operator ==
                                    - operator !=
                                    - Equals
                                    - GetHashCode
            13/ InputParser
            14/ OutputFormatter
            15/ Program
            16/ TurnQueue
        */
    }
}