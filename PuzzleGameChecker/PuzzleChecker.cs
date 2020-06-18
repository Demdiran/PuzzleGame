using System.Collections.Generic;
using PuzzleGameDomain;

namespace PuzzleGameChecker
{
    public class PuzzleChecker
    {
        public static List<int> CheckPuzzle(Puzzle puzzle)
        {
            var errors = new List<int>();
            var board = puzzle.Board;
            for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < board[rowIndex].Length; columnIndex++)
                {
                    var rowCorrect = CheckRow(board[rowIndex], columnIndex);
                    if (rowCorrect)
                    {
                        var columnCorrect = CheckColumn(board, rowIndex);
                        if (columnCorrect)
                        {
                            var boxCorrect = CheckBox(board, rowIndex, columnIndex);
                            errors.Add(rowIndex * 9 + columnIndex);
                        }
                    }
                }
            }

            return errors;
        }

        private static bool CheckRow(Square[] row, int columnIndex)
        {
            return true;
        }

        private static bool CheckColumn(Square[][] board, int rowIndex)
        {
            return false;
        }

        private static bool CheckBox(Square[][] board, int rowIndex, int columnIndex)
        {
            return false;
        }
    }
}