namespace WeeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectingusertable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "WeeUser_Id", newName: "WeeChatID");
            RenameIndex(table: "dbo.Users", name: "IX_WeeUser_Id", newName: "IX_WeeChatID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_WeeChatID", newName: "IX_WeeUser_Id");
            RenameColumn(table: "dbo.Users", name: "WeeChatID", newName: "WeeUser_Id");
        }
    }
}
