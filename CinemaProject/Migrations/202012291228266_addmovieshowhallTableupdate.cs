namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmovieshowhallTableupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieShows", "Movieid", "dbo.Movies");
            DropForeignKey("dbo.MovieShowHalls", "MovieShowid", "dbo.MovieShows");
            DropIndex("dbo.MovieShowHalls", new[] { "MovieShowid" });
            DropIndex("dbo.MovieShows", new[] { "Movieid" });
            DropPrimaryKey("dbo.MovieShowHalls");
            AddColumn("dbo.MovieShowHalls", "Movieid", c => c.Int(nullable: false));
            AddColumn("dbo.MovieShowHalls", "date", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieShowHalls", "length", c => c.Double(nullable: false));
            AddPrimaryKey("dbo.MovieShowHalls", new[] { "Movieid", "Hallid" });
            CreateIndex("dbo.MovieShowHalls", "Movieid");
            AddForeignKey("dbo.MovieShowHalls", "Movieid", "dbo.Movies", "id", cascadeDelete: true);
            DropColumn("dbo.MovieShowHalls", "MovieShowid");
            DropTable("dbo.MovieShows");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MovieShows",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        length = c.Double(nullable: false),
                        Movieid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.MovieShowHalls", "MovieShowid", c => c.Int(nullable: false));
            DropForeignKey("dbo.MovieShowHalls", "Movieid", "dbo.Movies");
            DropIndex("dbo.MovieShowHalls", new[] { "Movieid" });
            DropPrimaryKey("dbo.MovieShowHalls");
            DropColumn("dbo.MovieShowHalls", "length");
            DropColumn("dbo.MovieShowHalls", "date");
            DropColumn("dbo.MovieShowHalls", "Movieid");
            AddPrimaryKey("dbo.MovieShowHalls", new[] { "MovieShowid", "Hallid" });
            CreateIndex("dbo.MovieShows", "Movieid");
            CreateIndex("dbo.MovieShowHalls", "MovieShowid");
            AddForeignKey("dbo.MovieShowHalls", "MovieShowid", "dbo.MovieShows", "id", cascadeDelete: true);
            AddForeignKey("dbo.MovieShows", "Movieid", "dbo.Movies", "id", cascadeDelete: true);
        }
    }
}
