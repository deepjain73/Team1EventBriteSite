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
                      .IsRequired();
                e.Property(i => i.Location)
                      .IsRequired()
                      .HasMaxLength(100);
                e.Property(i => i.Date)
                       .IsRequired();

                e.HasOne(i => i.EventCategory)
                       .WithMany()
                       .HasForeignKey(i => i.EventCategoryId);

                e.HasOne(i => i.EventType)
                        .WithMany()
                        .HasForeignKey(i => i.EventTypeId);
            });
        }
    }
}
