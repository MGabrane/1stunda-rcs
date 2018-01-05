namespace MeowDating.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CatProfiles", "CatDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CatProfiles", "CatDescription");
        }
    }
}
