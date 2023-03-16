namespace ChessGame
{
    //Board representation
    static class Board
    {
        //lowercase letters represent the black pieces and upercase letters represent the white pieces 

        //Two dimensional character array used to represent board
        public static char[,] ChessBoard =
        {
            {'r', 'n', 'b', 'q', 'k', 'b', 'n', 'r' },
            {'p', 'p', 'p', 'p', 'p', 'p', 'p', 'p' },
            {'-', '-', '-', '-', '-', '-', '-', '-' },
            {'-', '-', '-', '-', '-', '-', '-', '-' },
            {'-', '-', '-', '-', '-', '-', '-', '-' },
            {'-', '-', '-', '-', '-', '-', '-', '-' },
            {'P', 'P', 'P', 'P', 'P', 'P', 'P', 'P' },
            {'R', 'N', 'B', 'Q', 'K', 'B', 'N', 'R' } 
        };

    }
}
