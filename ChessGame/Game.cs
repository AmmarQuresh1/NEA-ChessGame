using System;

namespace ChessGame
{
    //Main part of program
    class Game
    {
        //Prints board using nested for loop to print out each element in board
        public static void PrintBoard()
        {
            for (int i = 0; i < Board.ChessBoard.GetLength(0); i++)
            {
                //Prints numbered co-ordinates on board
                Console.Write(8-i + "|  ");     
                for (int j = 0; j < Board.ChessBoard.GetLength(1); j++)
                {
                    Console.Write(Board.ChessBoard[i,j] + " ");
                }
                Console.WriteLine();
            }
            //Prints lettered co-ordinates underneath board
            Console.WriteLine("    _______________"+"\n    A B C D E F G H");
        }

        static void Main()
        {   
            int gameEnd = 0;
            bool whiteToPlay = true;

            //Gives instructions on how to play the game on first open
            Console.WriteLine("CHESS GAME" +
                "\n\nHow to play:\nUse the co-ordinates shown on the board to select a piece and move pieces." +
                "\nFor example, entering e2 when asked what piece to move and e4 when asked what square to move to." +
                "\nMake sure to enter co-ordinates in lowercase." +
                "\nWhite pieces are represented by uppercase characters and black pieces are lowercase." +
                "\n\nThis game plays like regular chess but without detection for checks, castling or en passant " +
                "\nso win by taking the black king." +
                "\n\nPress any key to continue to game...");
            Console.ReadKey();
            Console.Clear();

            //Game loop
            while (gameEnd == 0)
            {
                PrintBoard();
                Console.Write("\n");
                MoveGeneration.PieceLogic(whiteToPlay);
                if (whiteToPlay && gameEnd == 0)
                {
                    gameEnd = PlayMove.MakeMove();
                    whiteToPlay = false;
                }
                else if(!whiteToPlay && gameEnd == 0)
                {
                    gameEnd = PlayMove.BlackMove();
                    whiteToPlay = true;
                }
                Console.Clear();
            }

            //gameEnd can be one of three values
            //0 means the game is still ongoing, 1 means white has won and 2 means black has won
            if (gameEnd == 1)
            {
                PrintBoard();
                Console.WriteLine("--------------------\nWhite wins");
            }
            else if (gameEnd == 2)
            {
                PrintBoard();
                Console.WriteLine("--------------------\nBlack wins");
            }
        }
    }
}