namespace CharacterTestMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alignments",
                c => new
                    {
                        AlignmentId = c.Int(nullable: false, identity: true),
                        AlignmentName = c.String(),
                        AlignmentDescription = c.String(),
                    })
                .PrimaryKey(t => t.AlignmentId);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(),
                        CharacterAlign_AlignmentId = c.Int(),
                        CharacterClass_ClassId = c.Int(),
                        CharacterRace_RaceId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Alignments", t => t.CharacterAlign_AlignmentId)
                .ForeignKey("dbo.Classes", t => t.CharacterClass_ClassId)
                .ForeignKey("dbo.Races", t => t.CharacterRace_RaceId)
                .Index(t => t.CharacterAlign_AlignmentId)
                .Index(t => t.CharacterClass_ClassId)
                .Index(t => t.CharacterRace_RaceId);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                        ClassDescription = c.String(),
                        ClassHitDie = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        RaceId = c.Int(nullable: false, identity: true),
                        RaceName = c.String(),
                        RaceDescription = c.String(),
                        RaceSpeed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaceId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(),
                        LanguageDescription = c.String(),
                        Race_RaceId = c.Int(),
                    })
                .PrimaryKey(t => t.LanguageId)
                .ForeignKey("dbo.Races", t => t.Race_RaceId)
                .Index(t => t.Race_RaceId);
            
            CreateTable(
                "dbo.Traits",
                c => new
                    {
                        TraitId = c.Int(nullable: false, identity: true),
                        TraitName = c.String(),
                        TraitDescription = c.String(),
                        Race_RaceId = c.Int(),
                    })
                .PrimaryKey(t => t.TraitId)
                .ForeignKey("dbo.Races", t => t.Race_RaceId)
                .Index(t => t.Race_RaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "CharacterRace_RaceId", "dbo.Races");
            DropForeignKey("dbo.Traits", "Race_RaceId", "dbo.Races");
            DropForeignKey("dbo.Languages", "Race_RaceId", "dbo.Races");
            DropForeignKey("dbo.Characters", "CharacterClass_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Characters", "CharacterAlign_AlignmentId", "dbo.Alignments");
            DropIndex("dbo.Traits", new[] { "Race_RaceId" });
            DropIndex("dbo.Languages", new[] { "Race_RaceId" });
            DropIndex("dbo.Characters", new[] { "CharacterRace_RaceId" });
            DropIndex("dbo.Characters", new[] { "CharacterClass_ClassId" });
            DropIndex("dbo.Characters", new[] { "CharacterAlign_AlignmentId" });
            DropTable("dbo.Traits");
            DropTable("dbo.Languages");
            DropTable("dbo.Races");
            DropTable("dbo.Classes");
            DropTable("dbo.Characters");
            DropTable("dbo.Alignments");
        }
    }
}
