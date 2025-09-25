using ConsoleChess;

internal class Program
{
    private static void Main(string[] args)
    {
        Board board = new Board();
        board.InitBoard();
        bool isRunning = true;

        while (isRunning)
        {
            DrawBoard(board);
            Move? move = null;
            while (move == null)
            {
                Console.Write("Enter move: ");
                move = Move.Parse(Console.ReadLine()!);
                Piece piece = board.Squares[move!.FromRow, move.FromCol]!;
                if (move == null || piece == null)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input, try again!");
                }
                else if (!MoveValidator.IsValidMove(piece, move, board))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid move, try again!");
                }
            }
            board.ApplyMove(move);
            Console.Clear();
        }

        void DrawBoard(Board board)
        {
            Console.WriteLine("  a b c d e f g h");
            for (int row = 0; row < 8; row++)
            {
                Console.Write(8 - row);
                Console.Write(" ");

                for (int col = 0; col < 8; col++)
                {
                    Piece? piece = board.Squares[row, col];
                    Console.Write(piece?.ToString() ?? ".");
                    Console.Write(" ");
                }

                Console.WriteLine(8 - row);
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}