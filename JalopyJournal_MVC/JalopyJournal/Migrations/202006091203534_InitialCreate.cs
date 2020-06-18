namespace JalopyJournal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AirFilter",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FilterType = c.String(maxLength: 100),
                        Miles = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Single(nullable: false),
                        Notes = c.String(maxLength: 500),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fuel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Single(nullable: false),
                        FuelType = c.Int(nullable: false),
                        Miles = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Single(nullable: false),
                        Notes = c.String(maxLength: 500),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.FuelAdditive",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdditiveType = c.String(maxLength: 100),
                        Miles = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Single(nullable: false),
                        Notes = c.String(maxLength: 500),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.OilAdditive",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdditiveType = c.String(maxLength: 100),
                        Miles = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Single(nullable: false),
                        Notes = c.String(maxLength: 500),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
            CreateTable(
                "dbo.OilPlusFilter",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OilType = c.Int(nullable: false),
                        OilFilter = c.String(maxLength: 100),
                        Miles = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Cost = c.Single(nullable: false),
                        Notes = c.String(maxLength: 500),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Car", t => t.CarID, cascadeDelete: true)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OilPlusFilter", "CarID", "dbo.Car");
            DropForeignKey("dbo.OilAdditive", "CarID", "dbo.Car");
            DropForeignKey("dbo.FuelAdditive", "CarID", "dbo.Car");
            DropForeignKey("dbo.Fuel", "CarID", "dbo.Car");
            DropForeignKey("dbo.AirFilter", "CarID", "dbo.Car");
            DropIndex("dbo.OilPlusFilter", new[] { "CarID" });
            DropIndex("dbo.OilAdditive", new[] { "CarID" });
            DropIndex("dbo.FuelAdditive", new[] { "CarID" });
            DropIndex("dbo.Fuel", new[] { "CarID" });
            DropIndex("dbo.AirFilter", new[] { "CarID" });
            DropTable("dbo.OilPlusFilter");
            DropTable("dbo.OilAdditive");
            DropTable("dbo.FuelAdditive");
            DropTable("dbo.Fuel");
            DropTable("dbo.Car");
            DropTable("dbo.AirFilter");
        }
    }
}
