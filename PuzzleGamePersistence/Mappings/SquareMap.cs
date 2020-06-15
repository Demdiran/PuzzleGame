using FluentNHibernate.Mapping;
using PuzzleGameDomain;

namespace PuzzleGamePersistence.Mappings
{
    public class SquareMap: ClassMap<Square>
    {
        public SquareMap()
        {
            Id(x => x.Id);
            Map(x => x.IsHint);
            Map(x => x.Value);
            Table("Square");
        }
    }
}