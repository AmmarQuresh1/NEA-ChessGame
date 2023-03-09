using ChessGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    class MoveGeneration
    {
        public static List<int[]> moves = new List<int[]>();

        public static void PieceLogic(bool whiteToPlay)
        {
            char[] whitePieces = { 'P', 'R', 'N', 'B', 'Q', 'K' };
            char[] blackPieces = { 'p', 'r', 'n', 'b', 'q', 'k' };
            char[] allPieces = { 'P', 'R', 'N', 'B', 'Q', 'K', 'p', 'r', 'n', 'b', 'q', 'k' };


            char[,] boardArray = Board.ChessBoard;

            moves.Clear();

            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    //white pawn 
                    if (boardArray[i, j] == 'P' && whiteToPlay)
                    {

                        //looks at one square ahead, if that square is empty add to the list the index of the current square and index of the empty square
                        if (boardArray[i - 1, j] == '-')
                        {
                            moves.Add(new int[] { i, j, i - 1, j });
                        }

                        //for a pawn moving 2 squares ahead when on the second rank of the board
                        if (boardArray[i - 2, j] == '-' && i == 6)
                        {
                            moves.Add(new int[] { i, j, i - 2, j });
                        }

                        //search for pawn attacking squares
                        //set attacking square index location to '.'

                    }

                    //black pawn
                    else if (boardArray[i, j] == 'p' && !whiteToPlay)
                    {

                        //looks at one square ahead, if that square is empty add to the list the index of the current square and index of the empty square
                        if (boardArray[i + 1, j] == '-')
                        {
                            moves.Add(new int[] { i, j, i + 1, j });
                        }

                        //for a pawn moving 2 squares ahead when on the seventh rank of the board
                        if (boardArray[i + 2, j] == '-' && i == 1)
                        {
                            moves.Add(new int[] { i, j, i + 2, j });
                        }

                        //search for pawn attacking squares
                        //set attacking square index location to '.'

                    }

                    if (boardArray[i, j] == 'N' && whiteToPlay)
                    {
                        int y;
                        int x;
                        try
                        {
                            y = -2;
                            x = 1;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }



                        try
                        {
                            y = -1;
                            x = 2;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            y = 1;
                            x = 2;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            y = 2;
                            x = 1;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = 2;
                            x = -1;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = 1;
                            x = -2;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = -1;
                            x = -2;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = -2;
                            x = -1;
                            if (boardArray[i + y, j + x] == '-')
                            {
                                moves.Add(new int[] { i, j, i + y, j + x });
                            }
                            else
                            {
                                foreach (char piece in allPieces)
                                {
                                    try
                                    {
                                        if (boardArray[i + y, j + x] == piece)
                                        {
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[] { i, j, i + y, j + x });
                                            }
                                        }
                                    }
                                    catch (Exception) { }
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                    
                    //if a cell in the array is a white bishop
                    if (boardArray[i, j] == 'B' && whiteToPlay)
                    {
                        //loops inside board limits
                        for (int z = 1; i - z >= 0 && j + z <= 7; z++)
                        {
                            //searches bishop diagonal squares top right
                            if (boardArray[i - z, j + z] == '-')
                            {
                                //adds to psuedo legal move list, passing current position and the square it can legally move to.
                                moves.Add(new int[] { i, j, i - z, j + z } );
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
                                            //checks if current colour bishop is looking at opposite colour piece
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] & piece == Char.ToLower(piece) || Char.ToLower(boardArray[i, j]) == boardArray[i, j] & piece == Char.ToUpper(piece))
                                            {
                                                moves.Add(new int[]{i, j, i - z, j + z});
                                                //setting z to 100 stops the bishop searching more squares in the diagonal
                                                //this stops it from going through a enemy piece
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

                        for (int z = 1; i + z <= 7 && j + z <= 7; z++)
                        {
                            //searches bishop diagonal squares bottom right
                            if (boardArray[i + z, j + z] == '-')
                            {

                                moves.Add(new int[] { i, j , i + z, j + z } );
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
                                                moves.Add(new int[] { i, j, i + z, j + z });
                                                z = 100;
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

                        for (int z = 1; i + z <= 7 && j - z >= 0; z++)
                        {
                            //searches bishop diagonal squares bottom left
                            if (boardArray[i + z, j - z] == '-')
                            {

                                moves.Add(new int[] { i, j , i + z, j - z });
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
                                                moves.Add(new int[] { i, j, i + z, j - z });
                                                z = 100;
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

                        for (int z = 1; i - z >= 0 && j - z >= 0; z++)
                        {
                            //searches bishop diagonal squares top left
                            if (boardArray[i - z, j - z] == '-')
                            {

                                moves.Add(new int[]{ i, j, i - z, j - z  });
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
                                                moves.Add(new int[] { i, j, i - z, j - z } );
                                                z = 100;
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
        }
    }
}