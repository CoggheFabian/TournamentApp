namespace TournamentApp.Shared.Dtos
{
    public class RoundUserPointsDto
    {
        public int RoundId { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public int QuizRoundId { get; set; }
    }
}