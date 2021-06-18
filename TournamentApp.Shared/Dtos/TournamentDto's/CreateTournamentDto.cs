using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TournamentApp.Shared.Attributes;


namespace TournamentApp.Shared.Dtos
{
    public class CreateTournamentDto : DtoBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EnsureMinimumElements(2, ErrorMessage = "Atleast 2 people needs to be in a tournament")]
        public List<PlayerInTournamentDto> Players { get; set; }
        [Required]
        public DateTime TournamentDate { get; set; }

    }
}