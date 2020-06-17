namespace PuzzleGameDomain
{
    public class Square
    {
        public bool IsHint { get; set; }
        public int Value { get; set; }
        public Square(int value)
        {
            this.Value = value;
            this.IsHint = value != 0;
        }

        public Square(){}

        public virtual void BecomeHintIfNeeded()
        {
            IsHint = Value != 0;
        }
    }
}