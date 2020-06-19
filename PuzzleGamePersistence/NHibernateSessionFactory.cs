using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using PuzzleGamePersistence.Mappings;

namespace PuzzleGamePersistence
{
    public class NHibernateSessionFactory
    {
        public static ISessionFactory CreateSessionFactory(string connectionString)
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ShowSql()
                    .ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PuzzleMap>())
                .BuildSessionFactory();
        }
    }
}