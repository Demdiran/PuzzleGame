namespace PuzzleGameDomain.Rules
{
    public class StandardColumnRule : Rule
    {
        public StandardColumnRule(){}
        public override bool CheckSquareBreaksRule(Square[][] board, int squareRowIndex, int squareColumnIndex)
        {
            var breaksRule = false;
            var squareValue = board[squareRowIndex][squareColumnIndex].Value;
            if (squareValue != 0)
            {
                for (int rowIndex = 0; rowIndex < board.Length; rowIndex++)
                {
                    if (rowIndex != squareRowIndex && board[rowIndex][squareColumnIndex].Value == squareValue)
                        breaksRule = true;
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