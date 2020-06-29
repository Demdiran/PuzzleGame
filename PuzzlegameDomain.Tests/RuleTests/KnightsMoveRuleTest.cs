using NUnit.Framework;
using PuzzleGameDomain.Rules;

namespace PuzzleGameDomain.Tests.RuleTests
{
    [TestFixture]
    public class KnightsMoveRuleTest
    {
        [TestCase(0,1)]
        [TestCase(0, 3)]
        [TestCase(1,0)]
        [TestCase(1,4)]
        [TestCase(3,0)]
        [TestCase(3,4)]
        [TestCase(4,1)]
        [TestCase(4,3)]
        public void IfSameValueKnightsMoveAwayThenRuleBroken(int rowIndex, int columnIndex)
        {
            var ruleBroken = _knightsMoveRule.CheckSquareBreaksRule(_testBoard, rowIndex, columnIndex);
            Assert.True(ruleBroken);
        }

        [TestCase(1,1)]
        [TestCase(8,8)]
        [TestCase(4,4)]
        [TestCase(2,3)]
        public void IfSquareIsEmptyThenRuleNotBroken(int rowIndex, int columnIndex)
        {
            var ruleBroken = _knightsMoveRule.CheckSquareBreaksRule(_testBoard, rowIndex, columnIndex);
            Assert.False(ruleBroken);
        }

        [TestCase(0,5)]
        [TestCase(1,6)]
        [TestCase(1,7)]
        [TestCase(3,7)]
        [TestCase(6,0)]
        [TestCase(6,1)]
        public void IfNotSameValueKnightsMoveAwayThenRuleNotBroken(int rowIndex, int columnIndex)
        {
            var ruleBroken = _knightsMoveRule.CheckSquareBreaksRule(_testBoard, rowIndex, columnIndex);
            Assert.False(ruleBroken);
        }

        private readonly KnightsMoveRule _knightsMoveRule = new KnightsMoveRule();

        private readonly Square[][] _testBoard =
        {
            new[]
            {
                new Square(6), new Square(6), new Square(), new Square(6), new Square(), new Square(5), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(6), new Square(), new Square(), new Square(), new Square(6), new Square(4), new Square(5), new Square(4), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(6), new Square(), new Square(), new Square(), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(6), new Square(), new Square(), new Square(), new Square(6), new Square(6), new Square(), new Square(4), new Square()
            },
            new[]
            {
                new Square(), new Square(6), new Square(), new Square(6), new Square(), new Square(), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(4), new Square(4), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square()
            }
        };
    }
}