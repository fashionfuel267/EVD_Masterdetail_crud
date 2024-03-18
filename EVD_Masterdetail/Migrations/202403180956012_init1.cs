namespace EVD_Masterdetail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhotoAlbums", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.PhotoAlbums", "TotalPic", c => c.Int(nullable: false));
            DropColumn("dbo.PhotoAlbums", "Description");
            DropColumn("dbo.PhotoGalleries", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhotoGalleries", "Description", c => c.String());
            AddColumn("dbo.PhotoAlbums", "Description", c => c.String());
            DropColumn("dbo.PhotoAlbums", "TotalPic");
            DropColumn("dbo.PhotoAlbums", "Created");
        }
    }
}
