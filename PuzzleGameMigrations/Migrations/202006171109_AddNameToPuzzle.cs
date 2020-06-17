using FluentMigrator;

namespace PuzzleGameMigrations.Migrations
{
    [Migration(202006171109)]
    public class AddNameToPuzzle : Migration
    {
        public override void Up()
        {
            Alter.Table("Puzzle")
                .AddColumn("Name").AsString().Nullable();

            Execute.Sql(@"
                          UPDATE Puzzle
                          SET Name = Id");
        }

        public override void Down()
        {
            Delete.Column("Name").FromTable("Puzzle");
        }

    }
}