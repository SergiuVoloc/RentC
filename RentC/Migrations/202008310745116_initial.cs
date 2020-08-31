namespace RentC_ConsoleApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                        CouponCode = c.String(nullable: false, maxLength: 128),
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
                        CouponCode = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Coupons", t => t.CouponCode)
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
                "dbo.RolesPermissions",
                c => new
                    {
                        RolesPermissionID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        PermissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RolesPermissionID)
                .ForeignKey("dbo.Permissions", t => t.PermissionID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.PermissionID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Enabled = c.Byte(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.RolesPermissions", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.RolesPermissions", "PermissionID", "dbo.Permissions");
            DropForeignKey("dbo.Reservations", "ReservStatsID", "dbo.ReservationStatuses");
            DropForeignKey("dbo.Reservations", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "CouponCode", "dbo.Coupons");
            DropForeignKey("dbo.Cars", "Reservation_ReservationID", "dbo.Reservations");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.RolesPermissions", new[] { "PermissionID" });
            DropIndex("dbo.RolesPermissions", new[] { "RoleID" });
            DropIndex("dbo.Reservations", new[] { "CouponCode" });
            DropIndex("dbo.Reservations", new[] { "ReservStatsID" });
            DropIndex("dbo.Reservations", new[] { "CustomerID" });
            DropIndex("dbo.Cars", new[] { "Reservation_ReservationID" });
            DropTable("dbo.Users");
            DropTable("dbo.RolesPermissions");
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
