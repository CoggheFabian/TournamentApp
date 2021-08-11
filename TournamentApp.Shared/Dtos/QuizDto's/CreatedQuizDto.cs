using System;
using System.Collections.Generic;
using TournamentApp.Model;

namespace TournamentApp.Shared.Dtos
{
    public class CreatedQuizDto : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public List<PlayerInQuizDto> PlayerInQuizDtos { get; set; }

        public QuizRoundDto QuizRoundDto { get; set; }
    }
}