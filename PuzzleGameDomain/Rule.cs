namespace PuzzleGameDomain
{
    public abstract class Rule
    {
        public virtual int Id { get; set; }
        public abstract bool SquareBreaksRule(Square[][] board, int rowIndex, int columnIndex);

        public abstract Square[][] PropagateSquareInfluence(Square[][] board, int rowIndex, int columnIndex);

    }
}