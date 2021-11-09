namespace CanineRanch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GotRidOfDateTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GroomingRequest", "RequestTimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroomingRequest", "RequestTimeStamp", c => c.DateTime(nullable: false));
        }
    }
}
