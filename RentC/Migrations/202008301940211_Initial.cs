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
                "dbo.Coupons",
                c => new
                    {
                        CouponCode = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CouponCode);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        PermissionID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PermissionID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        CarID = c.Int(nullable: false),
                        CarPlate = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Location = c.String(),
                        CustomerID = c.Int(nullable: false),
                        ReservStatsID = c.Short(nullable: false),
                        CouponCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Coupons", t => t.CouponCode, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.ReservationStatuses", t => t.ReservStatsID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ReservStatsID)
                .Index(t => t.CouponCode);
            
            CreateTable(
                "dbo.ReservationStatuses",
                c => new
                    {
                        ReservStatsID = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ReservStatsID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        RolePermissionID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        PermissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RolePermissionID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Enabled = c.Byte(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ReservStatsID", "dbo.ReservationStatuses");
            DropForeignKey("dbo.Reservations", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "CouponCode", "dbo.Coupons");
            DropForeignKey("dbo.Cars", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.Reservations", new[] { "CouponCode" });
            DropIndex("dbo.Reservations", new[] { "ReservStatsID" });
            DropIndex("dbo.Reservations", new[] { "CustomerID" });
            DropIndex("dbo.Cars", new[] { "Reservation_ReservationID" });
            DropTable("dbo.Users");
            DropTable("dbo.RolePermissions");
            DropTable("dbo.Roles");
            DropTable("dbo.ReservationStatuses");
            DropTable("dbo.Reservations");
            DropTable("dbo.Permissions");
            DropTable("dbo.Customers");
            DropTable("dbo.Coupons");
            DropTable("dbo.Cars");
        }
    }
}
