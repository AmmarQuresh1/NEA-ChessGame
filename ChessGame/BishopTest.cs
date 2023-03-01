using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame
{
    internal class BishopTest
    {
        public static void PieceLogic(bool whiteToPlay)
        {
            //independant script for testing the movement of the bishop only
            //not to be run with main program in normal circumstance
            
            char[,] BishopTest =
            {
            {'.', '.', '.', '.', '.', '.', '.', '.' },
            {'.', '.', '.', '.', '.', '.', '.', '.' },
            {'.', '.', '.', '.', '.', '.', '.', '.' },
            {'.', '.', '.', '.', '.', '.', '.', '.' },
            {'.', '.', '.', '.', '.', '.', '.', '.' },
            {'.', '.', 'K', '.', '.', '.', '.', '.' },
            {'.', '.', '.', '.', '.', '.', '.', '.' },
            {'B', '.', '.', '.', '.', '.', '.', '.' }
            };

            for (int i = 0; i < BishopTest.GetLength(0); i++)
            {
                for (int j = 0; j < BishopTest.GetLength(1); j++)
                {
                    Console.Write(BishopTest[i, j]);
                }
                Console.WriteLine();
            }

            char[] whitePieces = { 'P', 'R', 'N', 'B', 'Q', 'K' };
            char[] blackPieces = { 'p', 'r', 'n', 'b', 'q', 'k' };
            char[] allPieces = { 'P', 'R', 'N', 'B', 'Q', 'K', 'p', 'r', 'n', 'b', 'q', 'k' };
            char[] enemyPieces;
            char[] friendlyPieces;

            if (whiteToPlay)
            {
                enemyPieces = blackPieces;
                friendlyPieces = whitePieces;
            }
            else
            {
                enemyPieces = whitePieces;
                friendlyPieces = blackPieces;
            }

            List<PLegal> move = new List<PLegal>();
            char[,] boardArray = BishopTest;

            //loop through 2d array which represents chess board
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    //if a cell in the array is a white bishop
                    if (boardArray[i, j] == 'B')
                    {
                        //loops inside board limits
                        for (int z = 1; i - z >= 0 && j + z <= 7; z++)
                        {
                            //searches bishop diagonal squares top right
                            if (boardArray[i - z, j + z] == '.')
                            {
                                //adds to psuedo legal move list, passing current position and the square it can legally move to.
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i - z, j + z } });
                            }
                            else
                            {
                                //searches if the piece on the square is an enemy piece
                                foreach (char piece in allPieces)
                                {
                                    //to avoid out of range errors 
                                    try
                                    {
                                        if (boardArray[i - z, j + z] == piece)
                                        {
                                            //checks if current colour bishop is looking at opposite colour bishop
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i,j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i - z, j + z } });
                                            }
                                            else
                                            {
                                                //setting z to 100 stops the bishop searching more squares in the diagonal
                                                //this stops it from going through a enemy piece
                                                z = 100;
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }

                        for (int z = 0; i + z <= 7 && j + z <= 7; z++)
                        {
                            //searches bishop diagonal squares bottom right
                            if (boardArray[i + z, j + z] == '.')
                            {

                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + z, j + z } });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                { 
                                    try
                                    {
                                        if (boardArray[i + z, j + z] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + z, j + z } });
                                            }
                                            else
                                            {
                                                z = 100;
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }

                        for (int z = 0; i + z <= 7 && j - z >= 0; z++)
                        {
                            //searches bishop diagonal squares bottom left
                            if (boardArray[i + z, j - z] == '.')
                            {
                                 
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + z, j - z } });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + z, j - z] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + z, j - z } });
                                            }
                                            else
                                            {
                                                z = 100;
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }

                        for (int z = 0; i - z >= 0 && j - z >= 0; z++)
                        {
                            //searches bishop diagonal squares top left
                            if (boardArray[i - z, j - z] == '.')
                            {

                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i - z, j - z } });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i - z, j - z] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i - z, j - z } });
                                            }
                                            else
                                            {
                                                z = 100;
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }

                        
                    }

                }
            }

            int count = 0;
            foreach (PLegal moves in move)
            {
                Console.WriteLine(moves);
                count = count + 1;
            }
            Console.WriteLine(count);



        }
    }
}
