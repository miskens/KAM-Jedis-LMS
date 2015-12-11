namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class longerDocumentDesc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Description", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "Description", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
