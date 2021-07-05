namespace MaintenanceTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelUp", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Vehicle", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.VehicleMaintenance", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleMaintenance", "OwnerId");
            DropColumn("dbo.Vehicle", "OwnerId");
            DropColumn("dbo.FuelUp", "OwnerId");
        }
    }
}
