using System;
using System.Collections.Generic;

namespace ChessGame
{
    class MoveGeneration
    {
        public static List<int[]> moves = new List<int[]>();
        static char[,] boardArray = Board.ChessBoard;
        static char[] allPieces = { 'P', 'R', 'N', 'B', 'Q', 'K'};

        static void WhitePawnLogic(int i, int j)
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
                    if (boardArray[i - 1, j + 1] == Char.ToLower(piece) && Char.ToUpper(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i - 1, j + 1 });
                    }
                }
                catch (Exception) { }
                try
                {
                    //pawn detecting what piece is on the top left diagonal square and if there is a piece it will be allowed to take 

                    if (boardArray[i - 1, j - 1] == Char.ToLower(piece) && Char.ToUpper(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i - 1, j - 1 });
                    }
                }
                catch (Exception) { }

            }
        }

        static void BlackPawnLogic(int i, int j)
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
                    if (boardArray[i + 1, j + 1] == Char.ToUpper(piece) && Char.ToLower(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i + 1, j + 1 });
                    }
                }
                catch (Exception) { }
                try
                {
                    //pawn detecting what piece is on the bottom left diagonal square and if there is a opposite colour piece it will be allowed to take 
                    if (boardArray[i + 1, j - 1] == Char.ToUpper(piece) && Char.ToLower(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i + 1, j - 1 });
                    }
                }
                catch (Exception) { }
            }
        }

        static void KnightsLogic(int i, int j, bool whiteToPlay)
        {
            int[,] knightMoves = new int[,] { { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };
            int x;
            int y;
            for (int l = 0; l < 8; l++)
            {
                x = knightMoves[l, 0];
                y = knightMoves[l, 1];

                try
                {
                    if (boardArray[i + x, j + y] == '-' && boardArray[i, j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + x, j + y });
                    }
                    else if(boardArray[i + x, j + y] == '-' && boardArray[i, j] == Char.ToLower(boardArray[i, j]) && !whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + x, j + y });
                        
                    }
                    else if(boardArray[i + x, j + y] != '-')
                    {
                        foreach (char piece in allPieces)
                        {
                            if (boardArray[i + x, j + y] == Char.ToLower(piece) && boardArray[i, j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                            {
                                moves.Add(new int[] { i, j, i + x, j + y });
                            }
                            else if (boardArray[i + x, j + y] == Char.ToUpper(piece) && boardArray[i, j] == Char.ToLower(boardArray[i, j]) && !whiteToPlay)
                            {
                                moves.Add(new int[] { i, j, i + x, j + y });
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        static void BishopsLogic(int i, int j, bool whiteToPlay)
        {
            bool end;
            int x = 0;
            int y = 0;

            for (int f = 0; f < 4; f++)
            {   
                switch (f)
                {
                    case 0:
                        x = -1;
                        y = -1;
                        break;
                    case 1:
                        x = -1;
                        y = 1;
                        break;
                    case 2:
                        x = 1;
                        y = -1;
                        break;
                    case 3:
                        x = 1;
                        y = 1;
                        break;
                }
                end = false;

                while (!end)
                {
                    try
                    {
                        if (boardArray[i + x, j + y] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });
                        }
                        else if (boardArray[i + x, j + y] == '-' && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });
                        }
                        else if (boardArray[i + x, j + y] != '-')
                        {
                            foreach (char piece in allPieces)
                            { 
                                if (boardArray[i + x, j + y] == Char.ToLower(piece) && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                                {
                                    moves.Add(new int[] { i, j, i + x, j + y });
                                    end = true;
                                    break;
                                }
                                else if (boardArray[i + x, j + y] == Char.ToUpper(piece) && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                                {
                                    moves.Add(new int[] { i, j, i + x, j + y });
                                    end = true;
                                    break;
                                }
                            }
                            end = true;
                        }
                    }
                    catch
                    {
                        end = true;
                    }
                    if (!end)
                    {
                        switch (x)
                        {
                            case var expression when x > 0:
                                x++;
                                break;

                            case var expression when x < 0:
                                x--;
                                break;
                        }
                        switch (y)
                        {
                            case var expression when y > 0:
                                y++;
                                break;

                            case var expression when y < 0:
                                y--;
                                break;
                        }
                    }
                    
                }
            }
        }

        static void RooksLogic(int i, int j, bool whiteToPlay)
        {
            bool end;
            int x = 0;
            int y = 0;
            
            for (int f = 0; f < 4; f++)
            {
                switch (f)
                {
                    case 0:
                        x = 0;
                        y = 1;
                        break;
                    case 1:
                        x = 0;
                        y = -1;
                        break;
                    case 2:
                        x = -1;
                        y = 0;
                        break;
                    case 3:
                        x = 1;
                        y = 0;
                        break;
                }
                end = false;

                while (!end)
                {
                    try
                    {
                        if (boardArray[i + x, j + y] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });
                        }
                        else if (boardArray[i + x, j + y] == '-' && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });
                        }
                        else if (boardArray[i + x, j + y] != '-')
                        {
                            foreach (char piece in allPieces)
                            {
                                if (boardArray[i + x, j + y] == Char.ToLower(piece) && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                                {
                                    moves.Add(new int[] { i, j, i + x, j + y });
                                    end = true;
                                    break;
                                }
                                else if (boardArray[i + x, j + y] == Char.ToUpper(piece) && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                                {
                                    moves.Add(new int[] { i, j, i + x, j + y });
                                    end = true;
                                    break;
                                }
                            }
                            end = true;
                        }
                    }
                    catch
                    {
                        end = true;
                    }
                    if (!end)
                    {
                        switch (x)
                        {
                            case var expression when x > 0:
                                x++;
                                break;

                            case var expression when x < 0:
                                x--;
                                break;
                        }
                        switch (y)
                        {
                            case var expression when y > 0:
                                y++;
                                break;

                            case var expression when y < 0:
                                y--;
                                break;
                        }
                    }

                }
            }
        }

        static void QueensLogic(int i, int j, bool whiteToPlay)
        {
            bool end;
            int x = 0;
            int y = 0;

            for (int f = 0; f < 8; f++)
            {
                switch (f)
                {
                    case 0:
                        x = 0;
                        y = 1;
                        break;
                    case 1:
                        x = 0;
                        y = -1;
                        break;
                    case 2:
                        x = -1;
                        y = 0;
                        break;
                    case 3:
                        x = 1;
                        y = 0;
                        break;
                    case 4:
                        x = -1;
                        y = -1;
                        break;
                    case 5:
                        x = -1;
                        y = 1;
                        break;
                    case 6:
                        x = 1;
                        y = -1;
                        break;
                    case 7:
                        x = 1;
                        y = 1;
                        break;
                }
                end = false;

                while (!end)
                {
                    try
                    {
                        if (boardArray[i + x, j + y] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });
                        }
                        else if (boardArray[i + x, j + y] == '-' && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });
                        }
                        else if (boardArray[i + x, j + y] != '-')
                        {
                            foreach (char piece in allPieces)
                            {
                                if (boardArray[i + x, j + y] == Char.ToLower(piece) && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                                {
                                    moves.Add(new int[] { i, j, i + x, j + y });
                                    end = true;
                                    break;
                                }
                                else if (boardArray[i + x, j + y] == Char.ToUpper(piece) && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                                {
                                    moves.Add(new int[] { i, j, i + x, j + y });
                                    end = true;
                                    break;
                                }
                            }
                            end = true;
                        }
                    }
                    catch
                    {
                        end = true;
                    }
                    if (!end)
                    {
                        switch (x)
                        {
                            case var expression when x > 0:
                                x++;
                                break;

                            case var expression when x < 0:
                                x--;
                                break;
                        }
                        switch (y)
                        {
                            case var expression when y > 0:
                                y++;
                                break;

                            case var expression when y < 0:
                                y--;
                                break;
                        }
                    }

                }
            }
        }

        static void KingsLogic(int i, int j, bool whiteToPlay)
        {
            int[,] kingMoves = new int[,] { { -1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 } };
            int x;
            int y;
            for (int l = 0; l < 8; l++)
            {
                x = kingMoves[l, 0];
                y = kingMoves[l, 1];

                try
                {
                    if (boardArray[i + x, j + y] == '-' && boardArray[i, j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + x, j + y });
                    }
                    else if (boardArray[i + x, j + y] == '-' && boardArray[i, j] == Char.ToLower(boardArray[i, j]) && !whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + x, j + y });

                    }
                    else if (boardArray[i + x, j + y] != '-')
                    {
                        foreach (char piece in allPieces)
                        {
                            if (boardArray[i + x, j + y] == Char.ToLower(piece) && boardArray[i, j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                            {
                                moves.Add(new int[] { i, j, i + x, j + y });
                            }
                            else if (boardArray[i + x, j + y] == Char.ToUpper(piece) && boardArray[i, j] == Char.ToLower(boardArray[i, j]) && !whiteToPlay)
                            {
                                moves.Add(new int[] { i, j, i + x, j + y });
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        public static void PieceLogic(bool whiteToPlay)
        {
            //clears previous moves in the move generator list
            moves.Clear();

            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    //white pawn 
                    if (boardArray[i, j] == 'P' && whiteToPlay)
                    {
                        WhitePawnLogic(i, j);
                    }

                    //black pawn
                    else if (boardArray[i, j] == 'p' && !whiteToPlay)
                    {
                        BlackPawnLogic(i, j);
                    }

                    //logic for knights
                    if (boardArray[i, j] == 'N' || boardArray[i, j] == 'n')
                    {
                        KnightsLogic(i, j, whiteToPlay);
                    }

                    //logic for bishops
                    if (boardArray[i, j] == 'B' || boardArray[i, j] == 'b')
                    {
                        BishopsLogic(i, j, whiteToPlay);
                    }

                    //logic for rooks
                    if (boardArray[i, j] == 'R' || boardArray[i, j] == 'r')
                    {
                        RooksLogic(i, j, whiteToPlay);
                    }

                    //logic for queens
                    if(boardArray[i, j] == 'Q' || boardArray[i, j] == 'q')
                    {
                        QueensLogic(i, j, whiteToPlay);
                    }

                    //logic for kings
                    if (boardArray[i, j] == 'K' || boardArray[i, j] == 'k')
                    {
                        KingsLogic(i, j, whiteToPlay);
                    }
                }
            }

            //FOR TESTING ONLY
            //shows number of possible moves and the co ordinates of pieces and the squares they can move to

            //int count = 0;
            //for (int i = 0; i < moves.Count; i++)
            //{
            //    Console.WriteLine(String.Join(" ", moves[i]));
            //    count += 1;
            //}
            //Console.WriteLine(count);


        }
    }
}








