namespace MaintenanceTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForgotDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleMaintenance",
                c => new
                    {
                        VehicleMaintenanceId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        MaintenanceName = c.String(nullable: false),
                        ShopName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.VehicleMaintenanceId)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleMaintenance", "VehicleId", "dbo.Vehicle");
            DropIndex("dbo.VehicleMaintenance", new[] { "VehicleId" });
            DropTable("dbo.VehicleMaintenance");
        }
    }
}
