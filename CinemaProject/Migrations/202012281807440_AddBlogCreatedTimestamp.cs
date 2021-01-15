namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlogCreatedTimestamp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Halls",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
       



        public override void Down()
        {
            DropTable("dbo.Halls");
        }
    }
}
