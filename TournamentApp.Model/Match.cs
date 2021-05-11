using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class Match : EntityBase
    {
        [JsonIgnore]
        public Player Player1 { get; set; }
        public int ScorePlayer1 { get; set; }

        [JsonIgnore]
        public Player Player2 { get; set; }
        public int ScorePlayer2 { get; set; }

        public bool IsMatchPlayed { get; set; }
    }
}