namespace WeeChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        LoginUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.LoginUser_Id)
                .Index(t => t.LoginUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "LoginUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "LoginUser_Id" });
            DropTable("dbo.Users");
        }
    }
}
