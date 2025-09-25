using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    enum PieceType { King, Queen, Rook, Bishop, Knight, Pawn }
    enum PieceColor { White, Black }

    internal class Piece
    {
        public PieceType Type { get; }
        public PieceColor Color { get; }

        public Piece(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }

        public override string ToString()
        {
            return Type switch
            {
                PieceType.King => Color == PieceColor.White ? "K" : "k",
                PieceType.Queen => Color == PieceColor.White ? "Q" : "q",
                PieceType.Rook => Color == PieceColor.White ? "R" : "r",
                PieceType.Bishop => Color == PieceColor.White ? "B" : "b",
                PieceType.Knight => Color == PieceColor.White ? "N" : "n",
                PieceType.Pawn => Color == PieceColor.White ? "P" : "p",
                _ => "."
            };
        }
    }
}
