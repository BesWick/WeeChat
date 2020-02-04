namespace WeeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversationUserModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "IsConnected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "IsConnected");
        }
    }
}
