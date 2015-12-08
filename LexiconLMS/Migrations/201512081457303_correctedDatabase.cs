namespace LexiconLMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctedDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "UserId", c => c.Int(nullable: false));
        }
    }
}
