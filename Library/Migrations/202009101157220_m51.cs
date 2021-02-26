namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m51 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GenreModels", "PhotoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GenreModels", "PhotoUrl");
        }
    }
}
