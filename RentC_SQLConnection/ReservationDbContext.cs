
using RentC.Models;
using System.Data.Entity;



namespace RentC_SQLConnection
{
    public class ReservationDbContext : DbContext
    {
        public DbSet<Reservation> Reservations { get; set; }
        public ReservationDbContext() : base("RentCarDatabase") { }
    }
}
