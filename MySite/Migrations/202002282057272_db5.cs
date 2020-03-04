﻿namespace MySite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContentDatas", "Title", c => c.String());
            AlterColumn("dbo.ContentDatas", "URLString", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContentDatas", "URLString", c => c.String(nullable: false));
            AlterColumn("dbo.ContentDatas", "Title", c => c.String(nullable: false));
        }
    }
}
