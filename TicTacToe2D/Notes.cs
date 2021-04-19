namespace TicTacToe2D
{
    public class Notes
    {
        /*
            TODO: should Controller be renamed to GameController? - possibly more than one controller required
            If predicate uses board & player & so does gamecontext - coupled? or cause stack overflow
            Validations 'linked' to ConsoleInput
            Is Turn class named correctly?
            Does GameContext need Validations & GamePredicate?

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
            12/ Field               - property Position
                                    - property FieldContents
            13/ Turn                - property Player
                                    - property Position       
            14/ Board               - property Dictionary FieldDictionary                         - GamePredicate
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
            15/ InputParser
            16/ OutputFormatter
            17/ Program
        */
    }
}