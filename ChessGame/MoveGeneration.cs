using ChessGame;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ChessGame
{
    class MoveGeneration
    {
        public static List<int[]> moves = new List<int[]>();
        static char[,] boardArray = Board.ChessBoard;
        static char[] allPieces = { 'P', 'R', 'N', 'B', 'Q', 'K', 'p', 'r', 'n', 'b', 'q', 'k' };

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
                    if (boardArray[i - 1, j + 1] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece)
                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                    {
                        
                        moves.Add(new int[] { i, j, i - 1, j + 1 }); 
                    }
                }
                catch (Exception) { }
            }

            //pawn detecting what piece is on the top left diagonal square and if there is a piece it will be allowed to take 
            foreach (char piece in allPieces)
            {
                try
                {
                    if (boardArray[i - 1, j - 1] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece)
                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
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
                    if (boardArray[i + 1, j + 1] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece)
                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                    {

                        moves.Add(new int[] { i, j, i + 1, j + 1 });
                        
                    }
                }
                catch (Exception) { }
            }

            //pawn detecting what piece is on the bottom left diagonal square and if there is a opposite colour piece it will be allowed to take 
            foreach (char piece in allPieces)
            {
                try
                {
                    if (boardArray[i + 1, j - 1] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece)
                        || Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece))
                    {

                        moves.Add(new int[] { i, j, i + 1, j - 1 });
                        
                    }
                }
                catch (Exception) { }
            }
        }

        static void KnightsLogic(int i, int j, bool whiteToPlay)
        {
            //each cell stores y move then x move
            int[,] knightMoves = new int[,] { { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };
            int y;
            int x;
            for (int l = 0; l < 8; l++)
            {
                y = knightMoves[l, 0];
                x = knightMoves[l, 1];

                try
                {
                    if (boardArray[i + y, j + x] == '-' && boardArray[i, j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + y, j + x });
                    }
                    else if(boardArray[i + y, j + x] == '-' && boardArray[i, j] == Char.ToLower(boardArray[i, j]) && !whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + y, j + x });
                        
                    }
                    foreach (char piece in allPieces)
                    {
                        if (boardArray[i + y, j + x] == piece && boardArray[i, j] == Char.ToUpper(boardArray[i, j])
                            && piece == Char.ToLower(piece) && whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + y, j + x });
                        }
                        else if(boardArray[i + y, j + x] == piece && boardArray[i, j] == Char.ToLower(boardArray[i, j]) 
                            && piece == Char.ToUpper(piece) && !whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + y, j + x });
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        //static void BishopsLogic(int i, int j, bool whiteToPlay)
        //{
        //    //loops inside board limits
        //    for (int z = 1; i - z >= 0 && j + z <= 7; z++)
        //    {
        //        //searches bishop diagonal squares top right
        //        if (boardArray[i - z, j + z] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
        //        {
        //            //adds to psuedo legal move list, passing current position and the square it can legally move to.
        //            moves.Add(new int[] { i, j, i - z, j + z });
        //        }
        //        else if (boardArray[i - z, j + z] == '-' && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
        //        {
        //            moves.Add(new int[] { i, j, i - z, j + z });
        //        }
        //        //searches if the piece on the square is an enemy piece
        //        foreach (char piece in allPieces)
        //        {
        //            //to avoid out of range errors 
        //            try
        //            {
        //                //checks if a white colour bishop is looking at opposite colour piece
        //                if (boardArray[i - z, j + z] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) && whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i - z, j + z });
        //                    //setting z to 100 stops the bishop searching more squares in the diagonal
        //                    //this stops it from going through an enemy or friendly piece 
        //                    z = 100;
        //                }
        //                //checks if a black colour bishop is looking at opposite colour piece
        //                else if (boardArray[i - z, j + z] == piece && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece) && !whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i - z, j + z });
        //                    z = 100;
        //                }
        //            }
        //            catch (Exception) { }
        //        }
        //    }

        //    for (int z = 1; i + z <= 7 && j + z <= 7; z++)
        //    {
        //        //searches bishop diagonal squares bottom right
        //        if (boardArray[i + z, j + z] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
        //        {
        //            moves.Add(new int[] { i, j, i + z, j + z });
        //        }
        //        else if (boardArray[i + z, j + z] == '-' && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
        //        {
        //            moves.Add(new int[] { i, j, i + z, j + z });
        //        }
        //        foreach (char piece in allPieces)
        //        {
        //            try
        //            {
        //                if (boardArray[i + z, j + z] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) && whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i + z, j + z });
        //                    z = 100;
        //                }
        //                else if (boardArray[i + z, j + z] == piece && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece) && !whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i + z, j + z });
        //                    z = 100;
        //                }
        //            }
        //            catch (Exception) { }
        //        }
        //    }

        //    for (int z = 1; i + z <= 7 && j - z >= 0; z++)
        //    {
        //        //searches bishop diagonal squares bottom left
        //        if (boardArray[i + z, j - z] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
        //        {
        //            moves.Add(new int[] { i, j, i + z, j - z });
        //        }
        //        else if(boardArray[i + z, j - z] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
        //        {
        //            moves.Add(new int[] { i, j, i + z, j - z });
        //        }
        //        foreach (char piece in allPieces)
        //        {
        //            try
        //            {
        //                if (boardArray[i + z, j - z] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) && whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i + z, j - z });
        //                    z = 100;
        //                }
        //                else if (boardArray[i + z, j - z] == piece && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece) && !whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i + z, j - z });
        //                    z = 100;
        //                }
        //            }
        //            catch (Exception) { }
        //        }
        //    }

        //    for (int z = 1; i - z >= 0 && j - z >= 0; z++)
        //    {
        //        //searches bishop diagonal squares top left
        //        if (boardArray[i - z, j - z] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
        //        {
        //            moves.Add(new int[] { i, j, i - z, j - z });
        //        }
        //        else if (boardArray[i - z, j - z] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
        //        {
        //            moves.Add(new int[] { i, j, i - z, j - z });
        //        }
        //        foreach (char piece in allPieces)
        //        {
        //            try
        //            {
        //                if (boardArray[i - z, j - z] == piece && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToLower(piece) && whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i - z, j - z });
        //                    z = 100;
        //                }
        //                else if (boardArray[i - z, j - z] == piece && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && piece == Char.ToUpper(piece) && !whiteToPlay)
        //                {
        //                    moves.Add(new int[] { i, j, i - z, j - z });
        //                    z = 100;
        //                }
        //            }
        //            catch (Exception) { }
        //        }
        //    }
        //}

        static void BishopsLogic(int i, int j, bool whiteToPlay)
        {
            bool end = false;
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

                while (!end)
                {
                    try
                    {
                        if (boardArray[i + x, j + y] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });

                            if (x > 0)
                            {
                                x++;
                            }
                            else if (x < 0)
                            {
                                x--;
                            }

                            if (y > 0)
                            {
                                y++;
                            }
                            else if (x < 0)
                            {
                                y--;
                            }
                        }
                        else if (boardArray[i + x, j + y] == '-' && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                        {
                            moves.Add(new int[] { i, j, i + x, j + y });
                            x++;

                            if (x > 0)
                            {
                                x++;
                            }
                            else if (x < 0)
                            {
                                x--;
                            }

                            if (y > 0)
                            {
                                y++;
                            }
                            else if (x < 0)
                            {
                                y--;
                            }
                        }
                        else
                        {
                            end = true;
                        }
                    }
                    catch {
                        end = true;
                    }
                    if (x > 0)
                    {
                        x++;
                    }
                    else if (x < 0)
                    {
                        x--;
                    }

                    if (y > 0)
                    {
                        y++;
                    }
                    else if (x < 0)
                    {
                        y--;
                    }
                }
            }
        }

        static void RooksLogic(int i, int j, bool whiteToPlay)
        {
            int x = 0;
            int y = 0;
            bool end = false;
            
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

                while (!end)
                {

                    Console.WriteLine(x);
                    
                    if (boardArray[i + x, j + y] == '-' && Char.ToUpper(boardArray[i, j]) == boardArray[i, j] && whiteToPlay)
                    {
                        //add try for only adding move
                        moves.Add(new int[] { i, j, i + x, j + y });
                        //x++
                    }
                    else if (boardArray[i + x, j + y] == '-' && Char.ToLower(boardArray[i, j]) == boardArray[i, j] && !whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + x, j + y });
                        //x++
                    }
                    else
                    {
                        end = true;
                    }
                    
                    if (x > 0)
                    {
                        x++;
                    }
                    else if (x < 0)
                    {
                        x--;
                    }

                    if (y > 0)
                    {
                        y++;
                    }
                    else if (x < 0)
                    {
                        y--;
                    }
                }
            }
        }

        public static void PieceLogic(bool whiteToPlay)
        {
            //clears previous moves
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








