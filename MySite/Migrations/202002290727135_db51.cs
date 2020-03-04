namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db51 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteImages",
                c => new
                    {
                        SiteImagesId = c.Int(nullable: false, identity: true),
                        ContentDataId = c.Int(nullable: false),
                        Image_url = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SiteImagesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiteImages");
        }
    }
}
