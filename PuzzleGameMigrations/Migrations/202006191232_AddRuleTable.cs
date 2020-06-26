using FluentMigrator;

namespace PuzzleGameMigrations.Migrations
{
    [Migration(202006191232)]
    public class AddRuleTable : Migration
    {
        public override void Up()
        {
            Create.Table("PuzzleRule")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("RuleName").AsString().NotNullable()
                .WithColumn("PuzzleId").AsInt64().ForeignKey("Puzzle", "Id");
        }

        public override void Down()
        {
            Delete.Table("PuzzleRule");
        }
    }
}