using System.Collections.Generic;

namespace TournamentApp.Shared.Dtos
{
    public class TournamentWithAllRoundsDto
    {
        public int RoundId { get; set; }
        public int? PreviousRoundId { get; set; }
        public int? WinnerNodeId { get; set; }
        public int? LoserNodeId { get; set; }
        public int? NodeSubRoundId { get; set; }
    }
}