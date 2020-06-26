using FluentNHibernate.Mapping;
using PuzzleGameDomain.Rules;

namespace PuzzleGamePersistence.Mappings
{
    public class StandardBoxRuleMap : SubclassMap<StandardBoxRule>
    {
        StandardBoxRuleMap()
        {
            DiscriminatorValue("StandardBoxRule");
        }
        
    }
}