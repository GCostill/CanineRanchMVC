namespace CanineRanch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuidIDToDog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dog", "ID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dog", "ID");
        }
    }
}
