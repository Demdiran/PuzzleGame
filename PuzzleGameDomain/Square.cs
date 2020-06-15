namespace PuzzleGameDomain
{
    public class Square
    {
        public int Id { get; set; }
        public Square(int value)
        {
            this.Value = value;
            this.IsHint = value != 0;
        }
        public bool IsHint { get; set; }
        public int Value { get; set; }
    }
}