using ConsoleChess;

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
        move = Move.Parse(Console.ReadLine());
        if (move == null)
            Console.WriteLine("Invalid input, try again!");
    }
    board.ApplyMove(move);
}

void DrawBoard(Board board)
{
    for (int i = 0; i < 8; i++)
    {
        for (int j = 0; j < 8; j++)
        {
            if(board.Squares[i, j] != null)
                Console.Write(board.Squares[i, j] + " ");
            else Console.Write("_ ");
        }
        Console.WriteLine();
    }
}




