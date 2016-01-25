namespace ProjectSophiaService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGameModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Description", c => c.String());
            AddColumn("dbo.Games", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "ImageUrl");
            DropColumn("dbo.Games", "Description");
        }
    }
}
