namespace WeeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "ScreenName", c => c.String());
            DropColumn("dbo.UserProfiles", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "UserName", c => c.String());
            DropColumn("dbo.UserProfiles", "ScreenName");
        }
    }
}
