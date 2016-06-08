namespace Produktkatalog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Namn = c.String(),
                        Pris = c.Double(nullable: false),
                        Beskrivning = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produkts");
        }
    }
}
