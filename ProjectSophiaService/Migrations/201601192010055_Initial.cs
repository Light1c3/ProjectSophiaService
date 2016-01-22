namespace ProjectSophiaService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Benchmarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        CPU = c.String(),
                        GPU = c.String(),
                        RAM = c.String(),
                        MinFPS = c.String(),
                        MaxFPS = c.String(),
                        AvgFPS = c.String(),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Publisher = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Benchmarks", "GameId", "dbo.Games");
            DropIndex("dbo.Benchmarks", new[] { "GameId" });
            DropTable("dbo.Games");
            DropTable("dbo.Benchmarks");
        }
    }
}
