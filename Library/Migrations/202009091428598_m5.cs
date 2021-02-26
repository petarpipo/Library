namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenreModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.BookModels", "GenreModel_id", c => c.Int());
            CreateIndex("dbo.BookModels", "GenreModel_id");
            AddForeignKey("dbo.BookModels", "GenreModel_id", "dbo.GenreModels", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookModels", "GenreModel_id", "dbo.GenreModels");
            DropIndex("dbo.BookModels", new[] { "GenreModel_id" });
            DropColumn("dbo.BookModels", "GenreModel_id");
            DropTable("dbo.GenreModels");
        }
    }
}
