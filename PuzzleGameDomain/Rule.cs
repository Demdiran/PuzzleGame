namespace PuzzleGameDomain
{
    public abstract class Rule
    {
        public virtual int Id { get; set; }
        public abstract bool CheckSquareBreaksRule(Square[][] board, int squareRowIndex, int squareColumnIndex);

        public abstract Square[][] PropagateSquareInfluence(Square[][] board, int squareRowIndex, int squareColumnIndex);

    }
}