namespace SocialNetwork.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeMigrationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authorization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PatronymicName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        City = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authorization", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.FriendEntity",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FriendId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.FriendId })
                .ForeignKey("dbo.Profile", t => t.FriendId)
                .ForeignKey("dbo.Profile", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.MessageEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        UserToId = c.Int(nullable: false),
                        UserFromId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.UserFromId)
                .ForeignKey("dbo.Profile", t => t.UserToId)
                .Index(t => t.UserToId)
                .Index(t => t.UserFromId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profile", "Id", "dbo.Authorization");
            DropForeignKey("dbo.MessageEntity", "UserToId", "dbo.Profile");
            DropForeignKey("dbo.MessageEntity", "UserFromId", "dbo.Profile");
            DropForeignKey("dbo.FriendEntity", "UserId", "dbo.Profile");
            DropForeignKey("dbo.FriendEntity", "FriendId", "dbo.Profile");
            DropIndex("dbo.MessageEntity", new[] { "UserFromId" });
            DropIndex("dbo.MessageEntity", new[] { "UserToId" });
            DropIndex("dbo.FriendEntity", new[] { "FriendId" });
            DropIndex("dbo.FriendEntity", new[] { "UserId" });
            DropIndex("dbo.Profile", new[] { "Id" });
            DropTable("dbo.MessageEntity");
            DropTable("dbo.FriendEntity");
            DropTable("dbo.Profile");
            DropTable("dbo.Authorization");
        }
    }
}
