using Microsoft.EntityFrameworkCore;
using RRModels;

namespace RRDL
{
    public class RestaurantDBContext : DbContext
    {
        // constructor needed to pass in connection string
        public RestaurantDBContext() : base()
        {
        }

        public RestaurantDBContext(DbContextOptions options) : base(options)
        {
        }

        //Declaring entities
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
            .Property(restaurant => restaurant.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Review>()
            .Property(review => review.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Reservation>()
            .Property(reservation => reservation.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>()
            .Property(customer => customer.Id)
            .ValueGeneratedOnAdd();
        }
    }
}