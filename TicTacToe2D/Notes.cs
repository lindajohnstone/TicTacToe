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

            Winning Lines: (dimension, column, row)
                Each dimension:
                    winning row
                        Position(dimension, 0, row); delta Position(0, 1, 0)
                        CreateWinningLine(Position.Factory_2DPosition(0, row), Position.Factory_2DPosition(1, 0), boardSize) 
                        x 3
                    winning column:
                        Position(dimension, column, 0); delta Position(0, 0, 1)
                        CreateWinningLine(Position.Factory_2DPosition(column, 0), Position.Factory_2DPosition(0, 1), boardSize); 
                        x 3
                    winning diagonals:
                        Position(dimension, 0, 0); delta Position(0, 1, 1)
                        CreateWinningLine(Position.Factory_2DPosition(0, 0), Position.Factory_2DPosition(1, 1), boardSize);
                        Position(dimension, (boardSize - 1), 0); delta Position(0, -1, 1)
                        CreateWinningLine(Position.Factory_2DPosition((boardSize - 1), 0), Position.Factory_2DPosition(-1, 1), boardSize); 
                        x 2
                    = 3 dimensions x 8
                == 24
                Top/middle/bottom 'face' - slice on row
                    winning row:
                        Position(0, 0, 0); Position(0, 1, 0)
                        Position(0, 0, 1); 
                        Position(0, 0, 2); 
                        Position(0, 0, row); delta Position(0, 1, 0)
                        x 3
                    winning column:
                        Position(0, 0, 0); (1, 0, 0)
                        Position(1, 0, 0); 
                        Position(2, 0, 0); 
                        Position(0, column, 0); delta Position(1, 0, 0)
                        x 3
                    winning diagonals:
                        Position(0, 0, 0); 
                        Position(1, 1, 1); 
                        Position(2, 2, 2);
                        Position(0, 0, 0); delta Position(1, 1, 1)
                        Position(2, 0, 2); 
                        Position(1, 1, 1); 
                        Position(0, 2, 0); 
                        Position((boardSize - 1), 0, (boardSize - 1)); delta Position(-1, 1, -1)
                        x 2
                    = 3 slices x 8
                == 24 + 24 = 48
                Top/middle/bottom 'face' - slice on column
                
        */
    }
}