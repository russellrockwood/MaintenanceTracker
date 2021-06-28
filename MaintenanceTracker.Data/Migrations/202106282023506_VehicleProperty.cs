namespace MaintenanceTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VehicleProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "VehicleModel", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Vehicle", "Model");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "Model", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Vehicle", "VehicleModel");
        }
    }
}
