namespace PuzzleGameDomain
{
    public class Puzzle
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Square[][] Board { get; set; }
        public Puzzle(){}
        public Puzzle(string[] puzzleStrings)
        {
            var rowCount = puzzleStrings.Length;
            Board = new Square[rowCount][];
            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                var rowString = puzzleStrings[rowIndex];
                var rowLength = rowString.Length;
                var row = new Square[rowLength];

                for (var columnIndex = 0; columnIndex < rowLength; columnIndex++)
                {
                    if (int.TryParse(rowString[columnIndex].ToString(), out var result))
                        row[columnIndex] = new Square(result);
                    else
                        row[columnIndex] = new Square(0);
                }
                Board[rowIndex] = row;
            }
        }
    }
}