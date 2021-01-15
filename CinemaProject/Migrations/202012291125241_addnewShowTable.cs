namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewShowTable : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Movies", t => t.Movieid, cascadeDelete: true)
                .Index(t => t.Movieid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieShows", "Movieid", "dbo.Movies");
            DropIndex("dbo.MovieShows", new[] { "Movieid" });
            DropTable("dbo.MovieShows");
        }
    }
}
