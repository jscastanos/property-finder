namespace propertyfinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tComment",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        PostId = c.String(maxLength: 50, unicode: false),
                        CommentId = c.String(maxLength: 50, unicode: false),
                        PersonId = c.String(maxLength: 50, unicode: false),
                        Comment = c.String(),
                        isReply = c.Int(),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tNotification",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        notificationId = c.String(maxLength: 50, unicode: false),
                        SenderId = c.String(maxLength: 50, unicode: false),
                        RecipientId = c.String(maxLength: 50, unicode: false),
                        Message = c.String(unicode: false),
                        DateCreated = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tPersonInfo",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        PersonId = c.String(maxLength: 50, unicode: false),
                        UserId = c.String(maxLength: 50, unicode: false),
                        Firstname = c.String(maxLength: 50, unicode: false),
                        Middlename = c.String(maxLength: 50, unicode: false),
                        Lastname = c.String(maxLength: 50, unicode: false),
                        Birthdate = c.DateTime(storeType: "date"),
                        Address = c.String(unicode: false),
                        ContactNo = c.String(maxLength: 50, unicode: false),
                        ProfileImg = c.Binary(),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tPostImage",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        ImgId = c.String(maxLength: 50, unicode: false),
                        PostId = c.String(maxLength: 50, unicode: false),
                        Image = c.Binary(),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tPost",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        PostId = c.String(maxLength: 50, unicode: false),
                        PropertyTypeId = c.String(maxLength: 50, unicode: false),
                        PersonId = c.String(maxLength: 50, unicode: false),
                        Title = c.String(maxLength: 50, unicode: false),
                        Description = c.String(unicode: false),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        ImgId = c.String(maxLength: 50, unicode: false),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        Category = c.Int(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tPropertyType",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        PropertyTypeId = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 50, unicode: false),
                        DateCreated = c.DateTime(),
                        DatedUpdated = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        Status = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tServiceEntity",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        ServiceEntityId = c.String(maxLength: 50, unicode: false),
                        PropertyTypeId = c.String(maxLength: 50, unicode: false),
                        ServiceEntityName = c.String(maxLength: 50, unicode: false),
                        ServiceEntityAddress = c.String(unicode: false),
                        ProfileImg = c.Binary(),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tUser",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 50, unicode: false),
                        AccountTypeId = c.Int(),
                        Username = c.String(maxLength: 50, unicode: false),
                        Password = c.String(maxLength: 50, unicode: false),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
            CreateTable(
                "dbo.tUserValidationId",
                c => new
                    {
                        recNo = c.Int(nullable: false, identity: true),
                        ValidationId = c.String(maxLength: 50, unicode: false),
                        PersonId = c.String(maxLength: 50, unicode: false),
                        Image = c.Binary(),
                        ImageDescription = c.String(maxLength: 50, unicode: false),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50, unicode: false),
                        UpdatedBy = c.String(maxLength: 50, unicode: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.recNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.vUserAcctStatus");
            DropTable("dbo.tUserValidationId");
            DropTable("dbo.tUser");
            DropTable("dbo.tServiceEntity");
            DropTable("dbo.tPropertyType");
            DropTable("dbo.tPost");
            DropTable("dbo.tPostImage");
            DropTable("dbo.tPersonInfo");
            DropTable("dbo.tNotification");
            DropTable("dbo.tComment");
        }
    }
}
