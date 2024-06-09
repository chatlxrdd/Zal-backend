using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<UserTournament> UserTournaments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTournament>()
                .HasKey(ut => new { ut.UserId, ut.TournamentId });

            modelBuilder.Entity<UserTournament>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTournaments)
                .HasForeignKey(ut => ut.UserId);

            modelBuilder.Entity<UserTournament>()
                .HasOne(ut => ut.Tournament)
                .WithMany(t => t.UserTournaments)
                .HasForeignKey(ut => ut.TournamentId);
        }
    }
}
