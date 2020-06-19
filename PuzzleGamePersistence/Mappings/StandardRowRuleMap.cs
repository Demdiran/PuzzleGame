using FluentNHibernate.Mapping;
using PuzzleGameDomain.Rules;

namespace PuzzleGamePersistence.Mappings
{
    public class StandardRowRuleMap : SubclassMap<StandardRowRule>
    {
        StandardRowRuleMap()
        {
            DiscriminatorValue("StandardRowRule");
        }
        
    }
}