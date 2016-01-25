namespace ProjectSophiaService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGameModelShotLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ShotLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "ShotLink");
        }
    }
}
