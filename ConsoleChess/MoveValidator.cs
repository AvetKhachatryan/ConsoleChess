using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    internal class MoveValidator
    {
        public static bool IsValidMove(Piece piece, Move move, Board board)
        {
            if (piece == null)
                return false;

            int fromRow = move.FromRow;
            int fromCol = move.FromCol;
            int toRow = move.ToRow;
            int toCol = move.ToCol;

            Piece target = board.Squares[toRow, toCol]!;
            if (target != null && (piece.Color == target.Color ||
                target.Type == PieceType.King))
            {
                return false;
            }
            int dRow = toRow - fromRow;
            int dCol = toCol - fromCol;
            switch (piece.Type)
            {
                case PieceType.Pawn:
                    if (piece.Color == PieceColor.White)
                    {
                        if (fromRow == 6 && dRow == -2 && dCol == 0 &&
                            board.Squares[5, fromCol] == null && target == null)
                            return true;
                        if (dRow == -1 && dCol == 0 && target == null)
                            return true;
                        // Taking
                        if (dRow == -1 && Math.Abs(dCol) == 1 && target != null && target.Color == PieceColor.Black)
                            return true;
                    }
                    else // Black
                    {
                        if (fromRow == 1 && dRow == 2 && dCol == 0 &&
                            board.Squares[2, fromCol] == null && target == null)
                            return true;
                        if (dRow == 1 && dCol == 0 && target == null)
                            return true;
                        if (dRow == 1 && Math.Abs(dCol) == 1 && target != null && target.Color == PieceColor.White)
                            return true;
                    }
                    break;
                case PieceType.Knight:
                    if (((dRow == 1 || dRow == -1) && (dCol == 2 || dCol == -2)) ||
                        ((dRow == 2 || dRow == -2) && (dCol == 1 || dCol == -1)))
                        return true;
                    break;
                default: 
                    return false;
            }
            return false;
        }
    }
}
