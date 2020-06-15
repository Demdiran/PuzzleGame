using FluentMigrator;

namespace PuzzleGameMigrations.Migrations
{
    [Migration(202006151010)]
    public class AddPuzzleSquareJoinTable : Migration
    {
        public override void Up()
        {
            Create.Table("Puzzle_Square_Join")
                .WithColumn("PuzzleId").AsInt64()
                .WithColumn("RowNumber").AsInt64()
                .WithColumn("ColumnNumber").AsInt64()
                .WithColumn("SquareID").AsInt64();

            Create.ForeignKey()
                .FromTable("Puzzle_Square_Join").ForeignColumn("PuzzleId")
                .ToTable("Puzzle").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("Puzzle_Square_Join").ForeignColumn("SquareID")
                .ToTable("Square").PrimaryColumn("Id");

            Create.PrimaryKey()
                .OnTable("Puzzle_Square_Join").Columns("PuzzleId", "RowNumber", "ColumnNumber");
        }

        public override void Down()
        {
            Delete.Table("Puzzle_Square_Join");
        }

    }
}