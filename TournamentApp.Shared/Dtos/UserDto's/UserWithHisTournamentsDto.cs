using System.Collections.Generic;
using System.Linq;

namespace TournamentApp.Shared.Dtos
{
    public class UserWithHisTournamentsDto
    {
        //public string UserName { get; set; }
        //public IEnumerable<IGrouping<int, TournamentWithUserDto>> TournamentWithUserDtos { get; set; }
        public List<TournamentWithUserDto> TournamentWithUserDtos { get; set; }
    }
}