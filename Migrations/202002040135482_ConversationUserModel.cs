namespace WeeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversationUserModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionID = c.String(nullable: false, maxLength: 128),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        UserProfile_UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConnectionID)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserId)
                .Index(t => t.UserProfile_UserId);
            
            DropColumn("dbo.UserProfiles", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.Connections", "UserProfile_UserId", "dbo.UserProfiles");
            DropIndex("dbo.Connections", new[] { "UserProfile_UserId" });
            DropTable("dbo.Connections");
        }
    }
}
