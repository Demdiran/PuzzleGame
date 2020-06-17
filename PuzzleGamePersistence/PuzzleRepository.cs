using System.Collections;
using System.Linq;
using NHibernate;
using PuzzleGameDomain;

namespace PuzzleGamePersistence
{
    public class PuzzleRepository : Repository<Puzzle>
    {
        public PuzzleRepository(ISession session) : base(session) {}

        public Puzzle GetPuzzle()
        {
            return Session.Query<Puzzle>().ToList()[0];
        }

        public Puzzle GetPuzzleById(int id)
        {
            return Session.Get<Puzzle>(id);
        }

        public IList GetPuzzleIds()
        {
            return Session.Query<Puzzle>().Select(x => x.Id).ToList();
        }

        public IList GetPuzzleNames()
        {
            return Session.Query<Puzzle>().Select(x => x.Name).ToList();
        }
    }
}