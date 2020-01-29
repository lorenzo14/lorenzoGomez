namespace MigrationsMiercoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 200),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.Title })
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            AddColumn("dbo.Blogs", "Url", c => c.String(maxLength: 30));
            AddColumn("dbo.Blogs", "Rating", c => c.Int(nullable: false));
            AlterColumn("dbo.Blogs", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Blogs", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "Url", c => c.String());
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "BlogId" });
            AlterColumn("dbo.Blogs", "Name", c => c.String());
            DropColumn("dbo.Blogs", "Rating");
            DropColumn("dbo.Blogs", "Url");
            DropTable("dbo.Posts");
        }
    }
}
