using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    internal class MoveValidator
    {
        public static bool IsValidMove(Piece piece, Move move, Board board)
        {
            if (piece == null)
            {
                return false;
            }
            Piece NextSquare = board.Squares[move.ToRow, move.ToCol]!;
            if (NextSquare != null && (piece.Color == NextSquare.Color ||
                NextSquare.Type == PieceType.King))
            {
                return false;
            }
            int dRow = move.ToRow - move.FromRow;
            int dCol = move.ToCol - move.FromCol;
            switch (piece.Type)
            {
                case PieceType.Pawn:
                    if (NextSquare == null && piece.Color == PieceColor.White && dRow == -1 && dCol == 0)
                        return true;
                    else if (NextSquare == null && piece.Color == PieceColor.Black && dRow == 1 && dCol == 0)
                        return true;
                    else if  (NextSquare != null && piece.Color == PieceColor.White && dRow == -1 && (dCol == 1 || dCol == -1))
                        return true;
                    else if (NextSquare != null && piece.Color == PieceColor.Black && dRow == 1 && (dCol == 1 || dCol == -1))
                        return true;
                    break;
                case PieceType.Knight:
                    break;
                default: 
                    return false;
            }
            return false;
        }
    }
}
