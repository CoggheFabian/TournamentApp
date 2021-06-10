using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TournamentApp.Services.Dtos
{
    public class CreateTournamentDto : DtoBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public List<PlayerInTournamentDto> Players { get; set; }
        [Required]
        public DateTime TournamentDate { get; set; }

    }
}