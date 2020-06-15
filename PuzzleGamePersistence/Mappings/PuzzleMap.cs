using FluentNHibernate.Mapping;
using PuzzleGameDomain;

namespace PuzzleGamePersistence.Mappings
{
    public class PuzzleMap: ClassMap<Puzzle>
    {
        public PuzzleMap()
        {
            Id(x => x.Id);
            HasMany(x => x.Board)
                .Inverse()
                .AsList();
            Table("Puzzle");
        }
        
    }
}