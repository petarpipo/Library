namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.BookModels", "StoreModel_id", c => c.Int());
            CreateIndex("dbo.BookModels", "StoreModel_id");
            AddForeignKey("dbo.BookModels", "StoreModel_id", "dbo.StoreModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookModels", "StoreModel_id", "dbo.StoreModels");
            DropIndex("dbo.BookModels", new[] { "StoreModel_id" });
            DropColumn("dbo.BookModels", "StoreModel_id");
            DropTable("dbo.StoreModels");
        }
    }
}
