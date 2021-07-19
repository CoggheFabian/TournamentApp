using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class Quiz : EntityBase
    {
        public string QuizName { get; set; }
        public DateTime Date { get; set; }

        public int QuizOwnerId { get; set; }

        [JsonIgnore] public List<QuizRound> Rounds { get; set; }
    }
}