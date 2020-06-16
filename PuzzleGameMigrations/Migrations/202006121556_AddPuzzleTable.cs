using System;
using FluentMigrator;

namespace PuzzleGameMigrations.Migrations
{
    [Migration(202006121556)]
    public class AddPuzzleTable : Migration
    {
        public override void Up()
        {
            Create.Table("Puzzle")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Board").AsString(int.MaxValue);
        }

        public override void Down()
        {
            Delete.Table("Puzzle");
        }
    }
}