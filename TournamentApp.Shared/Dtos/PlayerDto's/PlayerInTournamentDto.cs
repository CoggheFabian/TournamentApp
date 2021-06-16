using System.ComponentModel.DataAnnotations;

namespace TournamentApp.Shared.Dtos
{
    public class PlayerInTournamentDto : DtoBase
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}