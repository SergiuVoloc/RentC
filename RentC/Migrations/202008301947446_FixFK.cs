namespace RentC_ConsoleApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFK : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RolePermissions", "RoleID");
            CreateIndex("dbo.RolePermissions", "PermissionID");
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.RolePermissions", "PermissionID", "dbo.Permissions", "PermissionID", cascadeDelete: true);
            AddForeignKey("dbo.RolePermissions", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "RoleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.RolePermissions", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.RolePermissions", "PermissionID", "dbo.Permissions");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.RolePermissions", new[] { "PermissionID" });
            DropIndex("dbo.RolePermissions", new[] { "RoleID" });
        }
    }
}
