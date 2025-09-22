using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    internal class Board
    {
        public Piece?[,] Squares { get; } = new Piece?[8, 8];

        public void InitBoard()
        {
            //Pawns
            for (int col = 0; col < 8; col++)
            {
                Squares[6, col] = new Piece(PieceType.Pawn, PieceColor.White);
                Squares[1, col] = new Piece(PieceType.Pawn, PieceColor.Black);
            }

            //White pieces
            Squares[7, 0] = new Piece(PieceType.Rook, PieceColor.White);
            Squares[7, 1] = new Piece(PieceType.Knight, PieceColor.White);
            Squares[7, 2] = new Piece(PieceType.Bishop, PieceColor.White);
            Squares[7, 3] = new Piece(PieceType.Queen, PieceColor.White);
            Squares[7, 4] = new Piece(PieceType.King, PieceColor.White);
            Squares[7, 5] = new Piece(PieceType.Bishop, PieceColor.White);
            Squares[7, 6] = new Piece(PieceType.Knight, PieceColor.White);
            Squares[7, 7] = new Piece(PieceType.Rook, PieceColor.White);

            //Black pieces
            Squares[0, 0] = new Piece(PieceType.Rook, PieceColor.Black);
            Squares[0, 1] = new Piece(PieceType.Knight, PieceColor.Black);
            Squares[0, 2] = new Piece(PieceType.Bishop, PieceColor.Black);
            Squares[0, 3] = new Piece(PieceType.Queen, PieceColor.Black);
            Squares[0, 4] = new Piece(PieceType.King, PieceColor.Black);
            Squares[0, 5] = new Piece(PieceType.Bishop, PieceColor.Black);
            Squares[0, 6] = new Piece(PieceType.Knight, PieceColor.Black);
            Squares[0, 7] = new Piece(PieceType.Rook, PieceColor.Black);
        }

        public void ApplyMove(Move move)
        {
            Piece? piece = Squares[move.FromRow, move.FromCol];
            Squares[move.ToRow, move.ToCol] = piece;
            Squares[move.FromRow, move.FromCol] = null;
        }
    }
}
