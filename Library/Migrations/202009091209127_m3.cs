namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookModels", "Published", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookModels", "Published");
        }
    }
}
