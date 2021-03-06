﻿using FluentNHibernate.Mapping;
using PuzzleGameDomain;
using PuzzleGamePersistence.CustomTypes;

namespace PuzzleGamePersistence.Mappings
{
    public class PuzzleMap: ClassMap<Puzzle>
    {
        public PuzzleMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Board)
                .CustomType(typeof(BoardType));
            HasMany(x => x.Rules)
                .Not.KeyNullable()
                .Not.Inverse()
                .KeyColumn("PuzzleId")
                .Table("PuzzleRule")
                .Cascade.All();
            Table("Puzzle");
        }
        
    }
}