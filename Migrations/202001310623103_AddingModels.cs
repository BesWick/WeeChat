namespace WeeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        WeeUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.WeeUser_Id)
                .Index(t => t.WeeUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "WeeUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "WeeUser_Id" });
            DropTable("dbo.Users");
        }
    }
}
