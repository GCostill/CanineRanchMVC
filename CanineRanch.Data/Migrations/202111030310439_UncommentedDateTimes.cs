namespace CanineRanch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UncommentedDateTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroomingRequest", "RequestTimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroomingRequest", "RequestTimeStamp");
        }
    }
}
