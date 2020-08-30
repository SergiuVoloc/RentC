namespace RentC_ConsoleApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        Plate = c.String(),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        PricePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location = c.String(),
                        Reservation_ReservationID = c.Int(),
                    })
                .PrimaryKey(t => t.CarID)
                .ForeignKey("dbo.Reservations", t => t.Reservation_ReservationID)
                .Index(t => t.Reservation_ReservationID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        CarPlate = c.String(),
                        CustomerID = c.Int(nullable: false),
                        ReservStatsID = c.Short(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        CouponCode = c.String(),
                    })
                .PrimaryKey(t => t.ReservationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.Cars", new[] { "Reservation_ReservationID" });
            DropTable("dbo.Reservations");
            DropTable("dbo.Cars");
        }
    }
}
