namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addn2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MoviesShows", "Movieid", "dbo.Movies");
            DropIndex("dbo.MoviesShows", new[] { "Movieid" });
            DropTable("dbo.MoviesShows");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MoviesShows",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        time = c.DateTime(nullable: false),
                        Movieid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.MoviesShows", "Movieid");
            AddForeignKey("dbo.MoviesShows", "Movieid", "dbo.Movies", "id", cascadeDelete: true);
        }
    }
}
