namespace MaintenanceTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialFuelUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FuelUp",
                c => new
                    {
                        FuelUpId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Miles = c.Double(nullable: false),
                        Gallons = c.Double(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.FuelUpId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FuelUp", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.FuelUp", new[] { "VehicleId" });
            DropTable("dbo.FuelUp");
        }
    }
}
