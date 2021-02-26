namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.BookModels", new[] { "GenreModel_id" });
            CreateIndex("dbo.BookModels", "GenreModel_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.BookModels", new[] { "GenreModel_Id" });
            CreateIndex("dbo.BookModels", "GenreModel_id");
        }
    }
}
