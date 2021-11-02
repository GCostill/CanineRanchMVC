namespace CanineRanch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IDsAddedToRequestModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroomingRequest", "ID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroomingRequest", "ID");
        }
    }
}
