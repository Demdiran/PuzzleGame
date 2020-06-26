using NUnit.Framework;
using NUnit.Framework.Internal;
using PuzzleGameDomain.Rules;

namespace PuzzleGameDomain.Tests.RuleTests
{
    [TestFixture]
    public class StandardBoxRuleTest
    {
        [TestCase(0,0)]
        [TestCase(2, 2)]
        [TestCase(0, 5)]
        [TestCase(1, 4)]
        public void IfSameValueInOtherSquareWithinBoxThenRuleBroken(int rowIndex, int columnIndex)
        {
            var ruleBroken = _standardBoxRule.CheckSquareBreaksRule(_testBoard, rowIndex, columnIndex);
            Assert.True(ruleBroken);
        }

        [TestCase(1,0)]
        [TestCase(0, 4)]
        [TestCase(8, 8)]
        public void IfSquareIsEmptyThenRuleNotBroken(int rowIndex, int columnIndex)
        {
            var ruleBroken = _standardBoxRule.CheckSquareBreaksRule(_testBoard, rowIndex, columnIndex);
            Assert.False(ruleBroken);
        }

        [TestCase(1,7)]
        [TestCase(3, 7)]
        public void IfNotSameValueInOtherSquaresInBoxThenRuleNotBroken(int rowIndex, int columnIndex)
        {
            var ruleBroken = _standardBoxRule.CheckSquareBreaksRule(_testBoard, rowIndex, columnIndex);
            Assert.False(ruleBroken);
        }

        private readonly StandardBoxRule _standardBoxRule = new StandardBoxRule();

        private readonly Square[][] _testBoard =
        {
            new[]
            {
                new Square(6), new Square(), new Square(), new Square(), new Square(), new Square(5), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(), new Square(), new Square(5), new Square(), new Square(), new Square(4), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(6), new Square(), new Square(), new Square(), new Square(), new Square(), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(4), new Square()
            },
            new[]
            {
                new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square(), new Square()
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