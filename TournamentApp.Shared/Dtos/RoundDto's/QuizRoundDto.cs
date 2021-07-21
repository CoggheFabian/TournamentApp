using System;

namespace TournamentApp.Shared.Dtos
{
    public class QuizRoundDto : DtoBase
    {
        public int Id { get; set; }
        public string RoundName { get; set; }
        public int MaxScorePerRound { get; set; }
        public int QuizId { get; set; }
    }
}