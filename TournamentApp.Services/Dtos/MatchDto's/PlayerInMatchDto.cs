using TournamentApp.Model;

namespace TournamentApp.Services.Dtos
{
    public class PlayerInMatchDto
    {
        public PlayerInTournamentDto Player1 { get; set; }
        public PlayerInTournamentDto Player2 { get; set; }
    }
}