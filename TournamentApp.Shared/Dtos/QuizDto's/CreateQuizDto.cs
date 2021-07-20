using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TournamentApp.Shared.Attributes;


namespace TournamentApp.Shared.Dtos
{
    public class CreateQuizDto : DtoBase
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [EnsureMinimumElements(2, ErrorMessage = "Atleast 2 people needs to be in a tournament")]
        public List<PlayerInQuizDto> Players { get; set; }

        public int QuizOwnerId { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        public QuizRoundDto Round { get; set; }

    }
}