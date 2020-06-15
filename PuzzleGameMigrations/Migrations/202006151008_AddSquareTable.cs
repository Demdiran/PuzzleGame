using FluentMigrator;

namespace PuzzleGameMigrations.Migrations
{
    [Migration(202006151008)]
    public class AddSquareTable : Migration
    {
        public override void Up()
        {
            Create.Table("Square")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("IsHint").AsBoolean()
                .WithColumn("Value").AsInt64();
        }

        public override void Down()
        {
            Delete.Table("Square");
        }

    }
}