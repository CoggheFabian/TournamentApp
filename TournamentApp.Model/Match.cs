using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class Match : EntityBase
    {
        [JsonIgnore]
        public User Player1 { get; set; }

        public int Player1Id { get; set; }
        public int ScorePlayer1 { get; set; }

        [JsonIgnore]
        public User Player2 { get; set; }


        public int Player2Id { get; set; }
        public int ScorePlayer2 { get; set; }

        public bool IsMatchPlayed { get; set; }

        public int RoundId { get; set; }
    }
}