namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddhseatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeatLists",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        seatNumber = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Hallid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Halls", t => t.Hallid, cascadeDelete: true)
                .Index(t => t.Hallid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeatLists", "Hallid", "dbo.Halls");
            DropIndex("dbo.SeatLists", new[] { "Hallid" });
            DropTable("dbo.SeatLists");
        }
    }
}
