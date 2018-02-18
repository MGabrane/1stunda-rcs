namespace MeowDating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogThings", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogThings", "UserId");
        }
    }
}
