namespace ProjectSophiaService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGameModelShortLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ShortLink", c => c.String());
            DropColumn("dbo.Games", "ShotLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "ShotLink", c => c.String());
            DropColumn("dbo.Games", "ShortLink");
        }
    }
}
