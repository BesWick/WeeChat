namespace WeeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Status");
        }
    }
}
