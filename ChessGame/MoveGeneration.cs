using System;
using System.Collections.Generic;

namespace ChessGame
{
    //Move Generator for Legal chess moves
    class MoveGeneration
    {
        //defines the list of arrays that will store the possible legal moves
        //inside each array of the list 4 things will be stored
        //The row and column the piece is in and the row and column it can move to
        public static List<int[]> moves = new List<int[]>();

        static char[,] boardArray = Board.ChessBoard;
        static char[] allPieces = { 'P', 'R', 'N', 'B', 'Q', 'K'};

        //Move logic for white pawns
        static void WhitePawnLogic(int i, int j)
        {
            //try and catch blocks are used to avoid out of range errors
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

            //loops through the allPieces array for piece capture logic
            foreach (char piece in allPieces)
            {
                try
                {
                    //if there is an opposite colour piece to the top left of the pawn it can take it
                    if (boardArray[i - 1, j + 1] == Char.ToLower(piece) && Char.ToUpper(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i - 1, j + 1 });
                    }
                }
                catch (Exception) { }
                try
                {
                    //if there is an opposite colour piece to the top right of the pawn it can take it
                    if (boardArray[i - 1, j - 1] == Char.ToLower(piece) && Char.ToUpper(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i - 1, j - 1 });
                    }
                }
                catch (Exception) { }

            }
        }

        //Move logic for black pawns
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

            foreach (char piece in allPieces)
            {
                try
                {
                    //if there is an opposite colour piece to the bottom right of the pawn it can take it
                    if (boardArray[i + 1, j + 1] == Char.ToUpper(piece) && Char.ToLower(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i + 1, j + 1 });
                    }
                }
                catch (Exception) { }
                try
                {
                    //if there is an opposite colour piece to the bottom left of the pawn it can take it
                    if (boardArray[i + 1, j - 1] == Char.ToUpper(piece) && Char.ToLower(boardArray[i, j]) == boardArray[i, j])
                    {
                        moves.Add(new int[] { i, j, i + 1, j - 1 });
                    }
                }
                catch (Exception) { }
            }
        }

        //Move logic for knights on board
        static void KnightsLogic(int i, int j, bool whiteToPlay)
        {
            //This array defines the positions the knight can jump to from it's current position
            int[,] knightMoves = new int[,] { { -2, 1 }, { -1, 2 }, { 1, 2 }, { 2, 1 }, { 2, -1 }, { 1, -2 }, { -1, -2 }, { -2, -1 } };

            int x;
            int y;
            for (int l = 0; l < 8; l++)
            {
                x = knightMoves[l, 0];
                y = knightMoves[l, 1];

                //to avoid out of range errors
                try
                {
                    //If the square the piece wants to move to is '-' (empty), and the knight is a white knight and it is white's turn to move 
                    if (boardArray[i + x, j + y] == '-' && boardArray[i, j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + x, j + y });
                    }
                    //Same as above but for a black knight when it is not white's turn to move
                    else if(boardArray[i + x, j + y] == '-' && boardArray[i, j] == Char.ToLower(boardArray[i, j]) && !whiteToPlay)
                    {
                        moves.Add(new int[] { i, j, i + x, j + y });
                    }
                    //if the square the knight wants to move to is not empty
                    else if(boardArray[i + x, j + y] != '-')
                    {
                        foreach (char piece in allPieces)
                        {
                            //Code is same to if statements above but here there is an addition of "boardArray[i + x, j + y] == Char.ToLower(piece)"
                            //That piece of code makes sure only opposite colour pieces can be taken
                            if (boardArray[i + x, j + y] == Char.ToLower(piece) && boardArray[i, j] == Char.ToUpper(boardArray[i, j]) && whiteToPlay)
                            {
                                moves.Add(new int[] { i, j, i + x, j + y });
                            }
                            //For black knights
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

        //Move logic for bishops on board
        static void BishopsLogic(int i, int j, bool whiteToPlay)
        {
            bool end;
            int x = 0;
            int y = 0;

            for (int f = 0; f < 4; f++)
            {   
                //The x and y variables that are being changed in the switch statements
                //represent the different directions the piece can move
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

                //end will be true once all squares in that direction have been searched for possible legal moves.
                //After that the the value of f will increase after the for loop runs again so another direction will be searched.
                while (!end)
                {
                    //to avoid out of range errors
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
                                    //setting end to true after taking a piece stops the unwanted behaviour of the piece being able to go through a piece
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
                        //Catch will be thrown when an out of range error happens,
                        //this means that the search is "falling off the board" so there are no more possible moves in the direction.
                        //Hence we set end to true
                        end = true;
                    }
                    if (!end)
                    {
                        //These switch statements increase the value of x and y if they are positive
                        //and decrease the value if they are negative.
                        //This makes it so the next square in the direction can be searched
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

        //Move logic for rooks on board
        static void RooksLogic(int i, int j, bool whiteToPlay)
        {
            bool end;
            int x = 0;
            int y = 0;
            
            //This method contains the same code from the BishopsLogic method.
            //The difference here is that the directions in this switch statement are changed
            //to be made suitable for the direction a Rook can travel.
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

        //Move logic for queens on board
        static void QueensLogic(int i, int j, bool whiteToPlay)
        {
            bool end;
            int x = 0;
            int y = 0;

            for (int f = 0; f < 8; f++)
            {
                //This method contains the same code from the BishopsLogic method.
                //The difference here is that the directions in this switch statement are changed
                //to be made suitable for the direction a Queen can travel.
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

        //Move logic for kings on board
        static void KingsLogic(int i, int j, bool whiteToPlay)
        {
            //Same code as KnightsLogic, but instead the array kingMoves replaces the array knightMoves, this array shows the possible moves for the king.
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

        //This method takes in the boolean whiteToPlay which if true means that it is white to move on the board
        //Therefore this script will only enter legal chess piece moves for the white pieces inside of the list of arrays "moves"
        public static void PieceLogic(bool whiteToPlay)
        {
            //Clears previous moves in the move generator list as the board will have been changed
            //after a move has been made.
            moves.Clear();

            //nested for loop that goes through every element of the 2D board array
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








