using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Van> Vans { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Attraction> Attractions { get; set; }

        // Tabelas associativas
        public DbSet<RouteCourier> RouteCouriers { get; set; }
        public DbSet<DeliveryAttraction> DeliveryAttractions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-Many: Route ↔ Courier
            modelBuilder.Entity<RouteCourier>()
                .HasKey(rc => new { rc.RouteId, rc.CourierId });

            modelBuilder.Entity<RouteCourier>()
                .HasOne(rc => rc.Route)
                .WithMany(r => r.RouteCouriers)
                .HasForeignKey(rc => rc.RouteId);

            modelBuilder.Entity<RouteCourier>()
                .HasOne(rc => rc.Courier)
                .WithMany(c => c.RouteCouriers)
                .HasForeignKey(rc => rc.CourierId);

            // Many-to-Many: Delivery ↔ Attraction
            modelBuilder.Entity<DeliveryAttraction>()
                .HasKey(da => new { da.DeliveryId, da.AttractionId });

            modelBuilder.Entity<DeliveryAttraction>()
                .HasOne(da => da.Delivery)
                .WithMany(d => d.DeliveryAttractions)
                .HasForeignKey(da => da.DeliveryId);

            modelBuilder.Entity<DeliveryAttraction>()
                .HasOne(da => da.Attraction)
                .WithMany(a => a.DeliveryAttractions)
                .HasForeignKey(da => da.AttractionId);

            // Relation 1:N → Van → Routes
            modelBuilder.Entity<Route>()
                .HasOne(r => r.Van)
                .WithMany(v => v.Routes)
                .HasForeignKey(r => r.VanId);

            // Relation 1:N → Route → Deliveries
            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Route)
                .WithMany(r => r.Deliveries)
                .HasForeignKey(d => d.RouteId);
        }
    }
}
