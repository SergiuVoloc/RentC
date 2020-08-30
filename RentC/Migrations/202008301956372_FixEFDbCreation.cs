namespace RentC_ConsoleApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixEFDbCreation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolePermissions", "PermissionID", "dbo.Permissions");
            DropForeignKey("dbo.RolePermissions", "RoleID", "dbo.Roles");
            DropIndex("dbo.RolePermissions", new[] { "RoleID" });
            DropIndex("dbo.RolePermissions", new[] { "PermissionID" });
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
            
            DropTable("dbo.RolePermissions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        RolePermissionID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        PermissionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RolePermissionID);
            
            DropForeignKey("dbo.RolesPermissions", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.RolesPermissions", "PermissionID", "dbo.Permissions");
            DropIndex("dbo.RolesPermissions", new[] { "PermissionID" });
            DropIndex("dbo.RolesPermissions", new[] { "RoleID" });
            DropTable("dbo.RolesPermissions");
            CreateIndex("dbo.RolePermissions", "PermissionID");
            CreateIndex("dbo.RolePermissions", "RoleID");
            AddForeignKey("dbo.RolePermissions", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.RolePermissions", "PermissionID", "dbo.Permissions", "PermissionID", cascadeDelete: true);
        }
    }
}
