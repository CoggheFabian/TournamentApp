using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TournamentApp.Model
{
    public class Round : EntityBase
    {

        [JsonIgnore]
        public Round PreviousRound { get; set; } // ref
        public int? PreviousRoundId { get; set; }

        [JsonIgnore]
        public Round WinnerNode { get; set; }// ref
        public int? WinnerNodeId { get; set; }


        [JsonIgnore]
        public Round LoserNode { get; set; } // ref
        public int? LoserNodeId { get; set; }

        public Round NodeSubRound { get; set; } // Embedded
        public int? NodeSubRoundId { get; set; }

        [JsonIgnore]
        public Tournament Tournament { get; set; } // ref

        public int TournamentId { get; set; }

        [JsonIgnore]
        public List<Match> Matches { get; set; } // Ref
    }
}