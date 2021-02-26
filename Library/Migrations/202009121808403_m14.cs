namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BookModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.GenreModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.StoreModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.StoreModels", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StoreModels", "City", c => c.String());
            AlterColumn("dbo.StoreModels", "Name", c => c.String());
            AlterColumn("dbo.GenreModels", "Name", c => c.String());
            AlterColumn("dbo.BookModels", "Name", c => c.String());
        }
    }
}
