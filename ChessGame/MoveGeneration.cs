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

            //clears previous moves
            moves.Clear();

            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    //white pawn 
                    if (boardArray[i, j] == 'P' && whiteToPlay)
                    {
                        try
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
                        }
                        catch { }
                        
                        //pawn detecting what piece is on the top right diagonal square and if there is a piece it will be allowed to take 
                        foreach (char piece in allPieces)
                        {
                            try
                            {
                                if (boardArray[i - 1, j + 1] == piece)
                                {
                                    if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) 
                                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                    {
                                        moves.Add(new int[] { i, j, i - 1, j + 1 });
                                    }
                                }
                            }
                            catch (Exception) { }
                        }

                        //pawn detecting what piece is on the top left diagonal square and if there is a piece it will be allowed to take 
                        foreach (char piece in allPieces)
                        {
                            try
                            {
                                if (boardArray[i - 1, j - 1] == piece)
                                {
                                    if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) 
                                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                    {
                                        moves.Add(new int[] { i, j, i - 1, j - 1 });
                                    }
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                    //black pawn
                    else if (boardArray[i, j] == 'p' && !whiteToPlay)
                    {
                        try
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
                        }
                        catch { }

                        //pawn detecting what piece is on the bottom left diagonal square and if there is a opposite colour piece it will be allowed to take 
                        foreach (char piece in allPieces)
                        {
                            try
                            {
                                if (boardArray[i + 1, j + 1] == piece)
                                {
                                    if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece)
                                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                    {
                                        moves.Add(new int[] { i, j, i + 1, j + 1 });
                                    }
                                }
                            }
                            catch (Exception) { }
                        }

                        //pawn detecting what piece is on the bottom left diagonal square and if there is a opposite colour piece it will be allowed to take 
                        foreach (char piece in allPieces)
                        {
                            try
                            {
                                if (boardArray[i + 1, j - 1] == piece)
                                {
                                    if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece)
                                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                                    {
                                        moves.Add(new int[] { i, j, i + 1, j - 1 });
                                    }
                                }
                            }
                            catch (Exception) { }
                        }

                    }

                    //logic for knights
                    if (boardArray[i, j] == 'N' || boardArray[i, j] == 'n')
                    {
                        //each cell stores y move then x move
                        int[,] knightMoves = new int[,] { { -2, 1 }, {-1, 2 }, {1, 2 }, {2, 1 }, {2,-1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };
                        int y = knightMoves[0,0];
                        int x = knightMoves[0, 1];
                        for (int l = 0; l < 8; l++)
                        {
                            try
                            {
                                if (boardArray[i + y, j + x] == '-' && boardArray[i,j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                                {
                                    moves.Add(new int[] { i, j, i + y, j + x });
                                }
                                else if(boardArray[i + y, j + x] == '-' && boardArray[i, j] == Char.ToLower(boardArray[i, j]) && !whiteToPlay) 
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
                                                if (boardArray[i, j] == Char.ToUpper(boardArray[i, j])  && piece == Char.ToLower(piece) && whiteToPlay)
                                                {
                                                    moves.Add(new int[] { i, j, i + y, j + x });
                                                }
                                                else if(boardArray[i, j] == Char.ToLower(boardArray[i, j])&& piece == Char.ToUpper(piece) && !whiteToPlay)
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
                            y = knightMoves[l, 0];
                            x = knightMoves[l, 1];
                        }
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
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] & piece == Char.ToLower(piece) 
                                                || Char.ToLower(boardArray[i, j]) == boardArray[i, j] & piece == Char.ToUpper(piece))
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
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) 
                                                || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
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
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) 
                                                || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
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
                                            if (Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) 
                                                || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
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
            int count = 0;
            for (int i = 0; i < moves.Count; i++)
            {
                Console.WriteLine(String.Join(" ", moves[i]));
                count += 1;
            }
            Console.WriteLine(count);
        }
    }
}