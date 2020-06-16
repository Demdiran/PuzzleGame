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
    }
}