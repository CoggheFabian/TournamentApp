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
                optionsBuilder.UseSqlServer("Server=localhost;user=SA;password=Prenk123-321Town;database=TournamentDB;trusted_connection=true;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(user => user.Player)
                .WithMany()
                .HasForeignKey(user => user.PlayerId)
                .OnDelete(DeleteBehavior.NoAction);

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