
using RentC.Models;
using System.Data.Entity;



namespace RentC_ConsoleApplication.DbContexts
{
    public class ReservationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Car> Cars { get; set; } 
        public ReservationDbContext() : base("RentCarDatabase") { }
    }
}
