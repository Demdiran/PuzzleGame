namespace PuzzleGameDomain.Rules
{
    public class StandardRowRule : Rule
    {
        public StandardRowRule(){}
        public override Square[][] PropagateSquareInfluence(Square[][] board, int rowIndex, int columnIndex)
        {
            throw new System.NotImplementedException();
        }

        public override bool CheckSquareBreaksRule(Square[][] board, int squareRowIndex, int squareColumnIndex)
        {
            var breaksRule = false;
            var squareValue = board[squareRowIndex][squareColumnIndex].Value;
            if (squareValue != 0)
            {
                for (int columnIndex = 0; columnIndex < board[0].Length; columnIndex++)
                {
                    if (columnIndex != squareColumnIndex && board[squareRowIndex][columnIndex].Value == squareValue) breaksRule = true;
                }
            }

            return breaksRule;
        }
    }
}