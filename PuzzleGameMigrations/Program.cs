using FluentMigrator.Runner;
using System;
using PuzzleGameMigrations.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace PuzzleGameMigrations
{
    class Program
    {
        private static readonly string _connectionString = "Data Source=localhost;Initial Catalog=PuzzleGame;Integrated Security=True";
        static void Main(string[] args)
        {
            DatabaseCreator.CreateDatabaseIfNotExists(_connectionString);

            try
            {
                var serviceProvider = CreateMigrationRunnerService(_connectionString);

                using (var scope = serviceProvider.CreateScope())
                {
                    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                    if (args.Length <= 0) args = new[] { "up" };
                    switch (args[0].ToLower())
                    {
                        case "up":
                            Upgrade(runner);
                            break;
                        case "down":
                            Downgrade(runner);
                            break;
                        case "target":
                            Target(runner, Convert.ToInt32(args[1]));
                            break;
                        default:
                            Console.WriteLine("Not a valid option. Valid options are:");
                            Console.WriteLine("-    up");
                            Console.WriteLine("-    down");
                            Console.WriteLine("-    target <VERSION>");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Check the arguments given to the application");
                Console.WriteLine("There was a problem: " + e.Message);
                Console.WriteLine("Stacktrace: " + e.StackTrace);
            }
        }

        /// <summary>
        /// Configure the dependency injection services
        /// </summary>
        /// <param name="connectionString"></param>
        private static IServiceProvider CreateMigrationRunnerService(string connectionString)
        {
            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQL support to FluentMigrator
                    .AddSqlServer()
                    // Set the connection string
                    .WithGlobalConnectionString(connectionString)
                    // Define the assembly containing the migrations
                    .ScanIn(typeof(AddPuzzleTable).Assembly).For.Migrations())
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        private static void Upgrade(IMigrationRunner runner)
        {
            if (!runner.HasMigrationsToApplyUp())
            {
                Console.WriteLine("No migration to apply");
                return;
            }

            runner.MigrateUp();
        }

        private static void Downgrade(IMigrationRunner runner)
        {
            if (!runner.HasMigrationsToApplyRollback())
            {
                Console.WriteLine("No migration to rollback");
                return;
            }

            runner.Rollback(1);
        }

        private static void Target(IMigrationRunner runner, int version)
        {
            if (runner.HasMigrationsToApplyDown(version))
            {
                runner.MigrateDown(version);
            }
            else if (runner.HasMigrationsToApplyUp(version))
            {
                runner.MigrateUp(version);
            }
        }
    }
}
