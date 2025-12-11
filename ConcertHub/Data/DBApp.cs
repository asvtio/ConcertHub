using ConcertHub.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertHub.Data
{
    public class DBApp : DbContext
    {
        public DBApp(DbContextOptions<DBApp> options)
       : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concert>()
         .Property(c => c.BaseTicketPrice)
         .HasPrecision(18, 2);

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Concerts)
                .WithOne(c => c.Artist)
                .HasForeignKey(c => c.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venue>()
                .HasMany(v => v.Concerts)
                .WithOne(c => c.Venue)
                .HasForeignKey(c => c.VenueId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Concert>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Concert)
                .HasForeignKey(t => t.ConcertId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tickets)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
