namespace GameStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewfildtogame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ImageData", c => c.Binary());
            AddColumn("dbo.Games", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "ImageMimeType");
            DropColumn("dbo.Games", "ImageData");
        }
    }
}
