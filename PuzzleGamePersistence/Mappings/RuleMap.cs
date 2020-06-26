using FluentNHibernate.Mapping;
using PuzzleGameDomain;

namespace PuzzleGamePersistence.Mappings
{
    public class RuleMap : ClassMap<Rule>
    {
        public RuleMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            DiscriminateSubClassesOnColumn("RuleName");
            Table("PuzzleRule");
        }
        
    }
}