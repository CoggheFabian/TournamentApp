namespace TournamentApp.Model
{
    public class RoundUserPoints : EntityBase
    {
        public int RoundId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
    }
}