
using RentC.Models;
using System.Data.Entity;



namespace RentC_ConsoleApplication.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext() : base("RentCarDatabase") { }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Car> Cars { get; set; } 
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ReservationStatuse> ReservationStatuses { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RolesPermission> RolesPermissions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
