namespace PetFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateImageProp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Image", c => c.Binary());
        }
    }
}
