namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmovieshowhallTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieShowHalls",
                c => new
                    {
                        MovieShowid = c.Int(nullable: false),
                        Hallid = c.Int(nullable: false),
                        id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieShowid, t.Hallid })
                .ForeignKey("dbo.Halls", t => t.Hallid, cascadeDelete: true)
                .ForeignKey("dbo.MovieShows", t => t.MovieShowid, cascadeDelete: true)
                .Index(t => t.MovieShowid)
                .Index(t => t.Hallid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieShowHalls", "MovieShowid", "dbo.MovieShows");
            DropForeignKey("dbo.MovieShowHalls", "Hallid", "dbo.Halls");
            DropIndex("dbo.MovieShowHalls", new[] { "Hallid" });
            DropIndex("dbo.MovieShowHalls", new[] { "MovieShowid" });
            DropTable("dbo.MovieShowHalls");
        }
    }
}
