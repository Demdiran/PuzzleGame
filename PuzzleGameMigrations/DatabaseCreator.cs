using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PuzzleGameMigrations
{
    public class DatabaseCreator
    {
        public static void CreateDatabaseIfNotExists(string connectionString)
        {
            var databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            try
            {
                ExecuteSql(connectionString, DatabaseCreationString(databaseName));

            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem creating the database: " + e);
                throw;
            }

        }
        private static void ExecuteSql(string connectionString, string sql)
        {
            using (var connection = new SqlConnection(GetConnectionStringToMasterDb(connectionString)))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
        }
        private static string GetConnectionStringToMasterDb(string connectionString)
        {
            var builder = new SqlConnectionStringBuilder(connectionString) { InitialCatalog = "master" };
            return builder.ConnectionString;
        }

        private static string DatabaseCreationString(string databaseName)
        {
            return $@"
                USE [master]

                IF DB_ID('{databaseName}') IS NULL
                    CREATE DATABASE [{databaseName}]
                     CONTAINMENT = NONE

                    IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
                    begin
                    EXEC [{databaseName}].[dbo].[sp_fulltext_database] @action = 'enable'
                    end

                    ALTER DATABASE [{databaseName}] SET ANSI_NULL_DEFAULT OFF

                    ALTER DATABASE [{databaseName}] SET ANSI_WARNINGS OFF 

                    ALTER DATABASE [{databaseName}] SET ARITHABORT OFF 

                    ALTER DATABASE [{databaseName}] SET AUTO_CLOSE OFF 

                    ALTER DATABASE [{databaseName}] SET AUTO_SHRINK OFF 

                    ALTER DATABASE [{databaseName}] SET AUTO_UPDATE_STATISTICS ON 

                    ALTER DATABASE [{databaseName}] SET CURSOR_CLOSE_ON_COMMIT OFF 

                    ALTER DATABASE [{databaseName}] SET CURSOR_DEFAULT  GLOBAL 

                    ALTER DATABASE [{databaseName}] SET CONCAT_NULL_YIELDS_NULL OFF 

                    ALTER DATABASE [{databaseName}] SET NUMERIC_ROUNDABORT OFF 

                    ALTER DATABASE [{databaseName}] SET QUOTED_IDENTIFIER OFF 

                    ALTER DATABASE [{databaseName}] SET RECURSIVE_TRIGGERS OFF 
                    
                    ALTER DATABASE [{databaseName}] SET  DISABLE_BROKER 

                    ALTER DATABASE [{databaseName}] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 

                    ALTER DATABASE [{databaseName}] SET DATE_CORRELATION_OPTIMIZATION OFF 

                    ALTER DATABASE [{databaseName}] SET TRUSTWORTHY OFF 

                    ALTER DATABASE [{databaseName}] SET ALLOW_SNAPSHOT_ISOLATION OFF 

                    ALTER DATABASE [{databaseName}] SET PARAMETERIZATION SIMPLE 

                    ALTER DATABASE [{databaseName}] SET READ_COMMITTED_SNAPSHOT OFF 

                    ALTER DATABASE [{databaseName}] SET HONOR_BROKER_PRIORITY OFF 

                    ALTER DATABASE [{databaseName}] SET RECOVERY FULL 

                    ALTER DATABASE [{databaseName}] SET  MULTI_USER 

                    ALTER DATABASE [{databaseName}] SET PAGE_VERIFY CHECKSUM  

                    ALTER DATABASE [{databaseName}] SET DB_CHAINING OFF 

                    ALTER DATABASE [{databaseName}] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 

                    ALTER DATABASE [{databaseName}] SET TARGET_RECOVERY_TIME = 60 SECONDS 

                    ALTER DATABASE [{databaseName}] SET  READ_WRITE 
            ";
        }

    }
}