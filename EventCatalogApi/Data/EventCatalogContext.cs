using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Data
{
    public class EventCatalogContext : DbContext
    {
        public EventCatalogContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventPrice> EventPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCategory>(e =>
            {
                e.ToTable("EventCategory");
                e.Property(c => c.Id)
                      .IsRequired()
                      .UseHiLo("event_category_hilo");

                e.Property(c => c.Category)
                    .IsRequired()
                    .HasMaxLength(100);

            });

            modelBuilder.Entity<EventType>(e =>
            {
                e.ToTable("EventTypes");
                e.Property(t => t.Id)
                      .IsRequired()
                      .UseHiLo("event_type_hilo");

                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventLocation>(e =>
            {
                e.ToTable("EventLocations");
                e.Property(l => l.Id)
                      .IsRequired()
                      .UseHiLo("event_location_hilo");

                e.Property(l => l.Location)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventPrice>(e =>
            {
                e.ToTable("EventPrices");
                e.Property(p => p.Id)
                      .IsRequired()
                      .UseHiLo("event_price_hilo");

                e.Property(p => p.eventPrice)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EventItem>(e =>
            {
                e.ToTable("Events");
                e.Property(i => i.Id)
                      .IsRequired()
                      .UseHiLo("events_hilo");

                e.Property(i => i.EventName)
                    .IsRequired()
                    .HasMaxLength(100);
                e.Property(i => i.Price)
                      .IsRequired()
                      .HasColumnType("float");
               e.Property(i => i.Date)
                       .IsRequired();
                e.Property(i => i.Venue)
                        .IsRequired()
                        .HasMaxLength(100);

                e.HasOne(i => i.EventCategory)
                       .WithMany()
                       .HasForeignKey(i => i.EventCategoryId);

                e.HasOne(i => i.EventType)
                        .WithMany()
                        .HasForeignKey(i => i.EventTypeId);

                e.HasOne(i => i.EventLocation)
                        .WithMany()
                        .HasForeignKey(i => i.EventLocationId);

                e.HasOne(i => i.EventPrice)
                       .WithMany()
                       .HasForeignKey(i => i.EventPriceId);
            });

        }
    }
}
