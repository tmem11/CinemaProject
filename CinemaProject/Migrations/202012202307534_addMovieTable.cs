namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        movieTitle = c.String(nullable: false),
                        releaseDate = c.DateTime(nullable: false),
                        description = c.String(nullable: false),
                        genere = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                        movieImage = c.String(),
                        porularity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
