using Microsoft.EntityFrameworkCore;

namespace TournamentApp.Model
{
    public class TournamentDbContext : DbContext
    {
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Round>()
                .HasOne(round => round.PreviousRound)
                .WithMany()
                .HasForeignKey(round => round.PreviousRoundId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Round>()
                .HasOne(round => round.WinnerNode)
                .WithMany()
                .HasForeignKey(round => round.WinnerNodeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Round>()
                .HasOne(round => round.LoserNode)
                .WithMany()
                .HasForeignKey(round => round.LoserNodeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Round>()
                .HasOne(round => round.NodeSubRound)
                .WithMany()
                .HasForeignKey(round => round.NodeSubRoundId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Round>()
                .HasOne(round => round.PreviousRound)
                .WithMany()
                .HasForeignKey(round => round.PreviousRoundId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);

        }
    }
}