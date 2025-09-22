using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChess
{
    internal class Move
    {
        public int FromRow { get; }
        public int FromCol { get; }
        public int ToRow { get; }
        public int ToCol { get; }

        private Move(int fromRow, int fromCol, int toRow, int toCol)
        {
            FromRow = fromRow;
            FromCol = fromCol;
            ToRow = toRow;
            ToCol = toCol;
        }

        public static Move? Parse(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 2) return null;

            var from = Convert(parts[0]);
            var to = Convert(parts[1]);

            if (from == null || to == null) return null;

            return new Move(from.Value.row, from.Value.col, to.Value.row, to.Value.col);
        }


        private static (int row, int col)? Convert(string pos)
        {
            if (pos.Length != 2) return null;

            char file = pos[0]; // a-h
            char rank = pos[1]; // 1-8

            if (file < 'a' || file > 'h') return null;
            if (rank < '1' || rank > '8') return null;

            int col = file - 'a';       // a→0, h→7
            int row = 8 - (rank - '0'); // 1→7, 8→0

            return (row, col);
        }


    }
}
