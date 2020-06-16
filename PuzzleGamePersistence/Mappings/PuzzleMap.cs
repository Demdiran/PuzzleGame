using FluentNHibernate.Mapping;
using PuzzleGameDomain;
using PuzzleGamePersistence.CustomTypes;

namespace PuzzleGamePersistence.Mappings
{
    public class PuzzleMap: ClassMap<Puzzle>
    {
        public PuzzleMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Board)
                .CustomType(typeof(BoardType));
            Table("Puzzle");
        }
        
    }
}