namespace PuzzleGameDomain
{
    public class Square
    {
        public Square(int value)
        {
            this.Value = value;
            this.IsHint = value != 0;
        }
        public bool IsHint { get; set; }
        public int Value { get; set; }
    }
}