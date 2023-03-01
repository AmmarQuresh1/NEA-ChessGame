using ChessGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessGame
{
    class MoveGeneration
    {
        public static void PieceLogic(bool whiteToPlay)
        {

            // directions
            int N = -8;
            int E = 1;
            int S = 8;
            int W = -1;

            int[] knightMoves = { N + N + E, E + N + E, E + S + E, S + S + E, S + S + W, W + S + W, W + N + W, N + N + W };

            char[] whitePieces = { 'P', 'R', 'N', 'B', 'Q', 'K' };
            char[] blackPieces = { 'p', 'r', 'n', 'b', 'q', 'k' };
            

            List<PLegal> move = new List<PLegal>();
            char[,] boardArray = Board.ChessBoard;

            for(int i = 0; i < boardArray.GetLength(0); i++)
            {
                for(int j = 0; j < boardArray.GetLength(1); j++)
                {
                    if (boardArray[i,j] == 'P')
                    {

                        //looks at one square ahead, if that square is empty add to the list the index of the current square and index of the empty square
                        if (boardArray[i - 1, j] == '.')
                        {
                            move.Add(new PLegal() { currentPos = new int[] {i, j}, moveablePos = new int[] {i - 1, j} });
                        }

                        if (boardArray[i - 2, j] == '.' && i == 6)
                        {
                            move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i - 2, j } });
                        }

                        //search for pawn attacking squares
                        //set attacking square index location to '.'

                    }

                    if (boardArray[i,j] == 'N')
                    {
                        int y;
                        int x;
                        try
                        {
                            y = -2;
                            x = 1;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }



                        try
                        {
                            y = -1;
                            x = 2;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            y = 1;
                            x = 2;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }

                        try
                        {
                            y = 2;
                            x = 1;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = 2;
                            x = -1;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = 1;
                            x = -2;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = -1;
                            x = -2;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }


                        try
                        {
                            y = -2;
                            x = -1;
                            if (boardArray[i + y, j + x] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                            }
                            else
                            {
                                foreach (char piece in blackPieces)
                                {
                                    if (boardArray[i + y, j + x] == piece)
                                    {
                                        move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i + y, j + x } });
                                    }
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                    if (boardArray[i, j] == 'B')
                    {
                        for (int z = 0; i-z >= 0 || i+j <= 7; z++)
                        {
                            while (boardArray[i-z,j+z] == '.')
                            {
                                move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i - z, j + z } });
                            }
                            move.Add(new PLegal() { currentPos = new int[] { i, j }, moveablePos = new int[] { i - z, j + z } });
                        }
                    }

                }
            }

            int count = 0;
            foreach(PLegal moves in move)
            {
                Console.WriteLine(moves);
                count = count + 1;
            }
            Console.WriteLine(count);
            
            
            
        }
    }
}

/*for (int i = 0; i < boardArray.Length; i++)
{
    if (boardArray[i, i] == 'P')
    {
        int direction = N;
        //looks at one square ahead, if that square is empty add to the list the index of the current square and index of the empty square
        if (boardArray[i + (direction * modifier)] == '.')
        {
            move.Add(new PLegal() { piece = i, moveableSquare = i + direction });
        }

        direction = N + N;
        if (boardArray[i + (direction * modifier)] == '.')
        {
            move.Add(new PLegal() { piece = i, moveableSquare = i + direction });
        }

        //search for pawn attacking squares
        //set attacking square index location to '.'

    }

    if (boardArray[i] == 'N')
    {
        foreach(int direction in knightMoves)
        {
            int y = 0;
            foreach(char fPiece in friendlyPieces)
            {
                //makes sure there are no duplicate entries
                y += 1;

                //if boardArray[i + direction] is out of range this stops program from crashing
                try
                {


                    //CHANGE TO 2D ARRAY BOARD, EASIER TO USE
                    char letter = boardArray[i + direction];
                    if (letter != fPiece & y == 6)
                    {
                        move.Add(new PLegal() { piece = i, moveableSquare = i + direction });
                    }
                }
                catch
                {

                }
            }
        }

    }

}*/






//if (boardArray[i + direction] == '.')
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}

//direction = N + N + E;
//if (boardArray[i + direction] == '.')
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}

//direction = E + E + N;
//if (boardArray[i + direction] == '.')
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}

//direction = E + E + S;
//if (boardArray[i + direction] == '.')
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}

//direction = S + S + E;
//if (boardArray[i + direction] == '.')
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}

//direction = S + S + W;
//if (boardArray[i + direction] == '.')
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}

//direction = W + W + S;
//if (boardArray[i + direction] == '.')
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}

//direction = W + W + N;
//if (boardArray[i + direction] == '.' )
//{
//    move.Add(new PLegal() { piece = boardArray[i], moveableSquare = boardArray[i + direction] });
//}