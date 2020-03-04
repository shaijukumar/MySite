namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.ContentDatas",
                c => new
                    {
                        ContentDataId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        URLString = c.String(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ContentDataId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContentDatas", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ContentDatas", new[] { "CategoryId" });
            DropTable("dbo.ContentDatas");
            DropTable("dbo.Categories");
        }
    }
}
