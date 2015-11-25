namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userForeignKeyToGroups : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Group_Id", "dbo.Groups");
            DropIndex("dbo.AspNetUsers", new[] { "Group_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Group_Id", newName: "GroupId");
            AlterColumn("dbo.AspNetUsers", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "GroupId");
            AddForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups");
            DropIndex("dbo.AspNetUsers", new[] { "GroupId" });
            AlterColumn("dbo.AspNetUsers", "GroupId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "GroupId", newName: "Group_Id");
            CreateIndex("dbo.AspNetUsers", "Group_Id");
            AddForeignKey("dbo.AspNetUsers", "Group_Id", "dbo.Groups", "Id");
        }
    }
}
