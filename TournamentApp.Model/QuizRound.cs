using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class QuizRound : EntityBase
    {
        [JsonIgnore]
        public Quiz Quiz { get; set; }

        public int QuizId { get; set; }

        public int MaxRoundScore { get; set; }

        public List<RoundUserPoints> UserPointsList { get; set; }

        public string RoundName { get; set; }
    }
}