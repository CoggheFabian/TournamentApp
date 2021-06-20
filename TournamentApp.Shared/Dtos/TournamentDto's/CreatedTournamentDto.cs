using System;
using System.Collections.Generic;
using TournamentApp.Model;

namespace TournamentApp.Shared.Dtos
{
    public class CreatedTournamentDto : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentDate { get; set; }

        public IEnumerable<Match> Matches { get; set; }

        public MainRoundForTournamentDto MainRoundForTournament { get; set; }
    }
}