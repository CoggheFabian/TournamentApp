using Microsoft.EntityFrameworkCore;
using TournamentApp.Model.ConfigManager;

namespace TournamentApp.Model
{
    public class TournamentDbContext : DbContext
    {
        private readonly IDbConfigManager _configManager;
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options, IDbConfigManager configManager) : base(options)
        {
            _configManager = configManager;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configManager.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<QuizRound> Rounds { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Leaderboard> Leaderboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Entity<QuizRound>()
            //     .HasOne(round => round.PreviousQuizRound)
            //     .WithMany()
            //     .HasForeignKey(round => round.PreviousRoundId)
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);
            //
            // modelBuilder.Entity<QuizRound>()
            //     .HasOne(round => round.WinnerNode)
            //     .WithMany()
            //     .HasForeignKey(round => round.WinnerNodeId)
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);
            //
            // modelBuilder.Entity<QuizRound>()
            //     .HasOne(round => round.LoserNode)
            //     .WithMany()
            //     .HasForeignKey(round => round.LoserNodeId)
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);
            //
            // modelBuilder.Entity<QuizRound>()
            //     .HasOne(round => round.NodeSubQuizRound)
            //     .WithMany()
            //     .HasForeignKey(round => round.NodeSubRoundId)
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);
            //
            // modelBuilder.Entity<QuizRound>()
            //     .HasOne(round => round.PreviousQuizRound)
            //     .WithMany()
            //     .HasForeignKey(round => round.PreviousRoundId)
            //     .OnDelete(DeleteBehavior.NoAction)
            //     .IsRequired(false);;
            //
            // modelBuilder.Entity<User>()
            //     .HasIndex(user => user.Email)
            //     .IsUnique();
            //
            //
            // modelBuilder.Entity<Match>()
            //     .HasOne(match => match.Player1)
            //     .WithMany()
            //     .HasForeignKey(match => match.Player1Id)
            //     .OnDelete(DeleteBehavior.NoAction);
            //
            // modelBuilder.Entity<Match>()
            //     .HasOne(u => u.Player2)
            //     .WithMany()
            //     .HasForeignKey(p => p.Player2Id);

            modelBuilder.Entity<Leaderboard>().ToSqlQuery(
                    "select U1.Name, sum(case when U1.Id = Matches.Player1Id then Matches.ScorePlayer1 else Matches.ScorePlayer2 end)  as score from Matches left join Users U1 on Matches.Player1Id = U1.Id or Matches.Player2Id = U1.Id where IsMatchPlayed = 1 group by U1.Name")
                .HasNoKey();

            base.OnModelCreating(modelBuilder);

        }
    }
}