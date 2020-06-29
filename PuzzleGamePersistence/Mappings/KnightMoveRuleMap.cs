using FluentNHibernate.Mapping;
using PuzzleGameDomain.Rules;

namespace PuzzleGamePersistence.Mappings
{
    public class KnightMoveRuleMap : SubclassMap<KnightsMoveRule>
    {
        KnightMoveRuleMap()
        {
            DiscriminatorValue("KnightsMoveRule");
        }
    }
}