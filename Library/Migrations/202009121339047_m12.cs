namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreModels", "PhotoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreModels", "PhotoUrl");
        }
    }
}
