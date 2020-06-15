using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PuzzleGameDomain;
using PuzzleGamePersistence;

namespace PuzzleGameAPI
{
    public class Program
    {
        private static readonly string _connectionString = "Data Source=localhost;Initial Catalog=PuzzleGame;Integrated Security=True";
        private static Repository<Puzzle> puzzleRepository = new Repository<Puzzle>(
            NHibernateSessionFactory
                .CreateSessionFactory(_connectionString)
                .OpenSession());
        public static void Main(string[] args)
        {
            var puzzle = new Puzzle(new[] {
                "----5----",
                "--9----3-",
                "---------",
                "-----1---",
                "-6--9--2-",
                "---------",
                "-------9-",
                "-9-------",
                "-4---8---"
            });
            puzzleRepository.SaveOrUpdate(puzzle);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
