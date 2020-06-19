namespace PuzzleGameDomain.Rules
{
    public class StandardRowRule : Rule
    {
        public StandardRowRule(){}
        public override Square[][] PropagateSquareInfluence(Square[][] board, int rowIndex, int columnIndex)
        {
            throw new System.NotImplementedException();
        }

        public override bool SquareBreaksRule(Square[][] board, int rowIndex, int columnIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}