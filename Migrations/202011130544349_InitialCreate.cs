namespace BookManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable:false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ISBN = c.String(),
                        PublicationYear = c.String(),
                        Stock = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        PublisherID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        ShelfID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherID, cascadeDelete: true)
                .ForeignKey("dbo.Shelves", t => t.ShelfID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.PublisherID)
                .Index(t => t.CategoryID)
                .Index(t => t.ShelfID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shelves",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "ShelfID", "dbo.Shelves");
            DropForeignKey("dbo.Books", "PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.Books", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "ShelfID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropIndex("dbo.Books", new[] { "PublisherID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropTable("dbo.Shelves");
            DropTable("dbo.Publishers");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
