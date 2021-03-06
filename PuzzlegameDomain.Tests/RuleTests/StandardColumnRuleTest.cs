﻿using NUnit.Framework;
using NUnit.Framework.Internal;
using PuzzleGameDomain.Rules;

namespace PuzzleGameDomain.Tests.RuleTests
{
    [TestFixture]
    public class StandardColumnRuleTest
    {
        private readonly StandardColumnRule _standardColumnRule = new StandardColumnRule();

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(2, 0)]
        [TestCase(1, 1)]
        public void IfEmptySquareCheckedThenRuleNotBroken(int rowIndex, int columnIndex)
        {
            var testBoard = new[] {
                new[] {new Square(), new Square(), new Square(9)},
                new[] {new Square(8), new Square(), new Square()},
                new[] {new Square(), new Square(), new Square()}
            };
            var ruleBroken = _standardColumnRule.CheckSquareBreaksRule(testBoard, rowIndex, columnIndex);
            Assert.False(ruleBroken);
        }

        [TestCase(0, 0)]
        [TestCase(0, 2)]
        [TestCase(1, 0)]
        [TestCase(2, 2)]
        [TestCase(2, 0)]
        public void IfNoSameValueInColumnThenRuleNotBroken(int rowIndex, int columnIndex)
        {
            var testBoard = new[] {
                new[] {new Square(7), new Square(4), new Square(9)},
                new[] {new Square(4), new Square(4), new Square(3)},
                new[] {new Square(9), new Square(), new Square(5)}
            };
            var ruleBroken = _standardColumnRule.CheckSquareBreaksRule(testBoard, rowIndex, columnIndex);
            Assert.False(ruleBroken);
        }

        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(0, 2)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        public void IfSameNonzeroValueInRowThenRuleBroken(int rowIndex, int columnIndex)
        {
            var testBoard = new[] {
                new[] {new Square(7), new Square(4), new Square(7)},
                new[] {new Square(7), new Square(7), new Square(7)},
                new[] {new Square(9), new Square(7), new Square(7)}
            };
            var ruleBroken = _standardColumnRule.CheckSquareBreaksRule(testBoard, rowIndex, columnIndex);
            Assert.True(ruleBroken);

        }
    }
}