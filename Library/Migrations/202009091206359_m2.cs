namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookModels", "About", c => c.String());
            AddColumn("dbo.BookModels", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookModels", "Price");
            DropColumn("dbo.BookModels", "About");
        }
    }
}
