using System.Collections.Generic;
using NUnit.Framework;
using PuzzleGameDomain.Rules;

namespace PuzzleGameDomain.Tests
{
    [TestFixture]
    public class PuzzleTest
    {
        [TestCase(new []{
            "--9-----9",
            "---4-----",
            "----5----",
            "---------",
            "---4-7---",
            "---------",
            "------8--",
            "-7------8",
            "------5--"
        }, 2, 8, 12, 39, 60, 71 )]
        public void TestBoardCheckerForStandardRules(string[] puzzleStrings, params int[] expectedResult)
        {
            var puzzle = new Puzzle(puzzleStrings);
            puzzle.Rules.Add(new StandardBoxRule());
            puzzle.Rules.Add(new StandardColumnRule());
            puzzle.Rules.Add(new StandardRowRule());

            var brokenSquareIndices = puzzle.CheckRules();
            CollectionAssert.AreEqual(expectedResult, brokenSquareIndices);
        }
    }
}