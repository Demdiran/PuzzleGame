namespace PuzzleGameDomain.Rules
{
    public class KnightsMoveRule : Rule
    {
        public override bool CheckSquareBreaksRule(Square[][] board, int squareRowIndex, int squareColumnIndex)
        {
            var breaksRule = false;
            var squareValue = board[squareRowIndex][squareColumnIndex].Value;
            if (squareValue != 0)
            {
                var topLeft = CheckTopLeftPair(board, squareRowIndex, squareColumnIndex, squareValue);
                var topRight = CheckTopRightPair(board, squareRowIndex, squareColumnIndex, squareValue);
                var bottomLeft = CheckBottomLeftPair(board, squareRowIndex, squareColumnIndex, squareValue);
                var bottomRight = checkBottomRightPair(board, squareRowIndex, squareColumnIndex, squareValue);
                breaksRule = topLeft || topRight || bottomLeft || bottomRight;
            }
            return breaksRule;
        }

        private bool CheckTopLeftPair(Square[][] board, int squareRowIndex, int squareColumnIndex, int squareValue)
        {
            var breaksRule = false;
            var leftRowIndex = squareRowIndex - 1;
            var leftColumnIndex = squareColumnIndex - 2;
            var topRowIndex = squareRowIndex - 2;
            var topColumnIndex = squareColumnIndex - 1;

            var leftInBounds = leftRowIndex >= 0 && leftColumnIndex >= 0;
            if(leftInBounds && board[leftRowIndex][leftColumnIndex].Value == squareValue)
                breaksRule = true;

            var topInBounds = topRowIndex >= 0 && topColumnIndex >= 0;
            if (topInBounds && board[topRowIndex][topColumnIndex].Value == squareValue)
                breaksRule = true;
                
            return breaksRule;
        }
        private bool CheckTopRightPair(Square[][] board, int squareRowIndex, int squareColumnIndex, int squareValue)
        {
            var breaksRule = false;
            var rightRowIndex = squareRowIndex - 1;
            var rightColumnIndex = squareColumnIndex + 2;
            var topRowIndex = squareRowIndex - 2;
            var topColumnIndex = squareColumnIndex + 1;

            var rightInBounds = rightRowIndex >= 0 && rightColumnIndex < 9;
            if (rightInBounds && board[rightRowIndex][rightColumnIndex].Value == squareValue)
                breaksRule = true;

            var topInBounds = topRowIndex >= 0 && topColumnIndex < 9;
            if (topInBounds && board[topRowIndex][topColumnIndex].Value == squareValue)
                breaksRule = true;

            return breaksRule;
        }
        private bool CheckBottomLeftPair(Square[][] board, int squareRowIndex, int squareColumnIndex, int squareValue)
        {
            var breaksRule = false;
            var leftRowIndex = squareRowIndex + 1;
            var leftColumnIndex = squareColumnIndex - 2;
            var bottomRowIndex = squareRowIndex + 2;
            var bottomColumnIndex = squareColumnIndex - 1;

            var rightInBounds = leftRowIndex < 9 && leftColumnIndex >= 0;
            if (rightInBounds && board[leftRowIndex][leftColumnIndex].Value == squareValue)
                breaksRule = true;

            var topInBounds = bottomRowIndex < 9 && bottomColumnIndex >= 0;
            if (topInBounds && board[bottomRowIndex][bottomColumnIndex].Value == squareValue)
                breaksRule = true;

            return breaksRule;
        }
        private bool checkBottomRightPair(Square[][] board, int squareRowIndex, int squareColumnIndex, int squareValue)
        {
            var breaksRule = false;
            var rightRowIndex = squareRowIndex + 1;
            var rightcolumnIndex = squareColumnIndex + 2;
            var bottomRowIndex = squareRowIndex + 2;
            var bottomColumnIndex = squareColumnIndex + 1;

            var rightInBounds = rightRowIndex < 9 && rightcolumnIndex < 9;
            if (rightInBounds && board[rightRowIndex][rightcolumnIndex].Value == squareValue)
                breaksRule = true;

            var topInBounds = bottomRowIndex < 9 && bottomColumnIndex < 9;
            if (topInBounds && board[bottomRowIndex][bottomColumnIndex].Value == squareValue)
                breaksRule = true;

            return breaksRule;
        }

        public override Square[][] PropagateSquareInfluence(Square[][] board, int squareRowIndex, int squareColumnIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}