using FluentNHibernate.Mapping;
using PuzzleGameDomain.Rules;

namespace PuzzleGamePersistence.Mappings
{
    public class StandardColumnRuleMap : SubclassMap<StandardColumnRule>
    {
        StandardColumnRuleMap()
        {
            DiscriminatorValue("StandardColumnRule");
        }

    }
}