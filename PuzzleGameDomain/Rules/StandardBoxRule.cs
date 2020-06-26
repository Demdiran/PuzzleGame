using System;

namespace PuzzleGameDomain.Rules
{
    public class StandardBoxRule : Rule
    {
        public override bool CheckSquareBreaksRule(Square[][] board, int squareRowIndex, int squareColumnIndex)
        {
            var breaksRule = false;
            var squareValue = board[squareRowIndex][squareColumnIndex].Value;
            if (squareValue != 0)
            {
                var boxRowIndex = (squareRowIndex / 3) * 3;
                var boxColumnIndex = (squareColumnIndex / 3) * 3;
                for (int rowIndex = boxRowIndex; rowIndex < boxRowIndex + 3; rowIndex++)
                {
                    for (int columnIndex = boxColumnIndex; columnIndex < boxColumnIndex + 3; columnIndex++)
                    {
                        var isSameSquare = rowIndex == squareRowIndex && columnIndex == squareColumnIndex;
                        if (!isSameSquare && board[rowIndex][columnIndex].Value == squareValue) breaksRule = true;
                    }
                }
            }
            return breaksRule;
        }

        public override Square[][] PropagateSquareInfluence(Square[][] board, int squareRowIndex, int squareColumnIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}