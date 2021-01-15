namespace CinemaProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tests");
        }
    }
}
