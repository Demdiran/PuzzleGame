using NHibernate;
namespace PuzzleGamePersistence
{
    public class Repository<TEntity> where TEntity:class
    {
        protected readonly ISession Session;

        public Repository(ISession session)
        {
            Session = session;
        }

        public void Add(TEntity entity)
        {
            Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            Session.Update(entity);
        }

        public void SaveOrUpdate(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public void Merge(TEntity entity)
        {
            Session.Merge(entity);
        }

        public void FlushAndClear()
        {
            Session.Flush();
            Session.Clear();
        }

        public void Remove(TEntity entity)
        {
            Session.Delete(entity);
        }
    }
}