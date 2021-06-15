using System;

namespace TournamentApp.Shared.Dtos
{
    public class CreatedTournamentDto : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TournamentDate { get; set; }
    }
}